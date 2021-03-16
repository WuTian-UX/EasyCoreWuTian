using System.ComponentModel.DataAnnotations;

namespace EasyCore.Entity
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
