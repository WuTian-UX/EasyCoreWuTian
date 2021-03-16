/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * JsonWebToken配置项的Model
 *  -------------------------------------------------------------------------*/
namespace EasyCore.Model
{
    public class JwtConfig
    {
        /// <summary>
        /// 发布者
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 发布者秘钥
        /// </summary>
        public string IssuerSigningKey { get; set; }
        /// <summary>
        /// Token有效的分钟数
        /// </summary>
        public int AccessTokenExpiresMinutes { get; set; }
    }
}
