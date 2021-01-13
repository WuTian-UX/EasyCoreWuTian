
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EasyCore.Entity
{
    [Table("LY_INTELLECT_SUPPUPLOADFILE")]  //指定数据库对应表名
    public class LY_INTELLECT_SUPPUPLOADFILE
    {
        [Key]  //主键
        [Column("B_ID")] //指定数据库对应表栏位名称
        public string B_ID { get; set; }

        [Column("TYPE_ID")]
        public int TYPE_ID { get; set; }

        [Column("FILE_NAME")]
        public string FILE_NAME { get; set; }
    }
}
