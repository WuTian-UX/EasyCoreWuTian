/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * JsonWebToken接口
 *  -------------------------------------------------------------------------*/
using EasyCore.Model;

namespace EasyCore.BLL
{
    public interface ITokenService
    {
        /// <summary>
        /// 将一个Model作为额外数据，生成token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <returns></returns>
        LoginViewModel CreateToken<T>(T user) where T : class;

        /// <summary>
        /// 创建 TOKEN 无负载数据
        /// </summary>
        /// <returns></returns>
        LoginViewModel CreateToken();


        /// <summary>
        /// 验证身份 验证签名的有效性
        /// </summary>
        /// <param name="encodeJwt"></param>
        void Validate(string encodeJwt);
    }
}
