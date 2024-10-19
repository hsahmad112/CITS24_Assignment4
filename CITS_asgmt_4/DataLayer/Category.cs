using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS_asgmt_4.DataLayer
{
    public class Category
    {
        [Key]
        [Column("categoriesid", TypeName = "int4")]
        public int Id { get; }
        [Column("categoryname", TypeName = "varchar")]
        [MaxLength(15)]
        public string? Name { get; set; }
        [Column("description", TypeName = "varchar")]
        [MaxLength(300)]
        public string? Description { get; set; }
    }
}
