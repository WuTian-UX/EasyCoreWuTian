/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * JsonWebToken服务
 *  -------------------------------------------------------------------------*/
using EasyCore.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EasyCore.BLL
{
    public class TokenService : ITokenService
    {

        #region 依赖注入

        private readonly IOptions<JwtConfig> _options;
        public TokenService(IOptions<JwtConfig> options)
        {
            _options = options;
        }

        #endregion


        #region 生成Token

        //创建 TOKEN 无负载数据
        public LoginViewModel CreateToken()
        {

            List<Claim> claims = new List<Claim>();

            return CreateToken(claims);

        }


        /// <summary>
        /// 通过反射将一个Model作为负载数据，生成token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <returns></returns>
        public LoginViewModel CreateToken<T>(T user) where T : class
        {


            //携带的额外数据，类似一个键值对
            List<Claim> claims = new List<Claim>();

            //填充负载数据的键值对
            foreach (var item in user.GetType().GetProperties())
            {
                object obj = item.GetValue(user);
                string value = "";
                if (obj != null)
                    value = obj.ToString();

                claims.Add(new Claim(item.Name, value));
            }

            //创建token
            return CreateToken(claims);

        }


        private LoginViewModel CreateToken(List<Claim> claims)
        {
            var now = DateTime.Now; var expires = now.Add(TimeSpan.FromMinutes(_options.Value.AccessTokenExpiresMinutes));
            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,//Token发布者
                audience: _options.Value.Audience,//Token接受者
                claims: claims,//携带的负载数据
                notBefore: now,//当前时间token生成时间
                expires: expires,//过期时间
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.IssuerSigningKey)), SecurityAlgorithms.HmacSha256));
            return new LoginViewModel { TokenStr = new JwtSecurityTokenHandler().WriteToken(token), Expires = expires };
        }
        #endregion

        #region 校验Token
        /// <summary>
        /// 验证身份 验证签名的有效性
        /// </summary>
        /// <param name="encodeJwt"></param>
        public void Validate(string encodeJwt)
        {

            var jwtArr = encodeJwt.Split('.');

            var header = JsonConvert.DeserializeObject<Dictionary<string, string>>(Base64UrlEncoder.Decode(jwtArr[0]));
            var payLoad = JsonConvert.DeserializeObject<Dictionary<string, string>>(Base64UrlEncoder.Decode(jwtArr[1]));
            //配置文件中取出来的签名秘钥
            var hs256 = new HMACSHA256(Encoding.ASCII.GetBytes(_options.Value.IssuerSigningKey));

            //验证签名是否正确（把用户传递的签名部分取出来和服务器生成的签名匹配即可）

            
            if (!string.Equals(jwtArr[2], Base64UrlEncoder.Encode(hs256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(jwtArr[0], ".", jwtArr[1]))))))
            {
                throw new Exception("JsonWebToken不正确");
            }


            //其次验证是否在有效期内（也应该必须）
            var now = ToUnixEpochDate(DateTime.UtcNow);

            if (now < long.Parse(payLoad["nbf"].ToString()) && now > long.Parse(payLoad["exp"].ToString()))
            {
                throw new Exception("JsonWebToken不在有效期");
            }


        }



        private long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        #endregion
    }
}
