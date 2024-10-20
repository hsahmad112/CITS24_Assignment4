using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CITS_asgmt_4.DataLayer
{
    [Table("categories", Schema = "public")]
    public class Category
    {

        [Column("categoryid", TypeName = "int4")]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("categoryname", TypeName = "varchar")]
        [MaxLength(15)]
        public string? Name { get; set; }
        [Column("description", TypeName = "varchar")]
        [MaxLength(300)]
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get;  set; }

       // public string ProductName => Product.Name;
    }

}
