/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * Chloe数据库实体
 *  -------------------------------------------------------------------------*/
using Chloe.Annotations;
namespace EasyCore.Entity
{

    [Table("DEMO_AGE")]
    public class DemoAge
    {

        [Column("ID", IsPrimaryKey = true)]
        public string ID { get; set; }

        [Column("AGE")]
        public string Age { get; set; }

    }
}
