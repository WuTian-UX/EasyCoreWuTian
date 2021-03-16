/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 
 *  -------------------------------------------------------------------------*/
using System.ComponentModel.DataAnnotations;

namespace EasyCore.Model
{
    public class DemoParaModel
    {
        /// <summary>
        /// 必填参数
        /// </summary>
        [Required]
        public string Age { get; set; }

        public string Name { get; set; }

    }
}
