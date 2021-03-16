/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 登录接口的返回模型
 *  -------------------------------------------------------------------------*/
using System;

namespace EasyCore.Model
{
    public class LoginViewModel
    {
        /// <summary>
        /// JsonWebToken字符串
        /// </summary>
        public string TokenStr { get; set; }
        /// <summary>
        /// JWT有效期
        /// </summary>
        public DateTime Expires { get; set; }
    }
}
