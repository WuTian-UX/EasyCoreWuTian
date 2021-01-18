/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 
 *  -------------------------------------------------------------------------*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCore.Entity
{
    [Table("DEMO_AGE")]
    public class Demo_Age
    {
        [Key]  
        [Column("ID")] 
        public string ID { get; set; }

        [Column("AGE")]
        public string Age { get; set; }


    }
}
