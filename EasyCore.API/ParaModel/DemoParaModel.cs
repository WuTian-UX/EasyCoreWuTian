using System.ComponentModel.DataAnnotations;

namespace EasyCore.API
{
    public class DemoParaModel
    {
        /// <summary>
        /// 必填参数
        /// </summary>
        [Required]
        public string Age { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// 每页数据数数量
        /// </summary>
        public string PageSize { get; set; }
    }
}
