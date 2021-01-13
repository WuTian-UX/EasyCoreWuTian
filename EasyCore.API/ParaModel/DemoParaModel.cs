using System.ComponentModel.DataAnnotations;

namespace EasyCore.API
{
    public class DemoParaModel
    {
        /// <summary>
        /// 必填参数
        /// </summary>
        [Required]
        public string ID { get; set; }
    }
}
