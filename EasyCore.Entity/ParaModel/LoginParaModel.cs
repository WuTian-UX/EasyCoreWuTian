/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 
 *  -------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyCore.Entity
{
    public class LoginParaModel
    {

        /// <summary>
        /// 用户登录名称（昵称）
        /// </summary>
        [Required]
        public string UserLoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        public string PassWord { get; set; }
    }
}
