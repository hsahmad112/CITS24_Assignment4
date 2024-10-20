using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CITS_asgmt_4.DataLayer
{
    [Table("products", Schema = "public")]
    public class Product
    {
        [Key]
        [Column("productid", TypeName = "int4")]
        public int Id { get; set; }
        [Column("productname", TypeName = "varchar")]
        [MaxLength(40)]
        public string? Name { get; set; }
        [Column("unitprice", TypeName = "int4")]
        public double UnitPrice { get; set; }
        [Column("quantityperunit", TypeName = "varchar")]
        public string QuantityPerUnit { get; set; }
        [Column("unitsinstock", TypeName = "int4")]
        public int UnitsInStock { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        [Column("categoryid", TypeName = "int4")]
        public int CategoryId { get; set; }
        [Column("categoryname", TypeName = "varchar")]
        public string CategoryName => Category.Name;
        public string ProductName => Name;

        public virtual ICollection<OrderDetails> OrderDetail { get; set; }

    }
}
