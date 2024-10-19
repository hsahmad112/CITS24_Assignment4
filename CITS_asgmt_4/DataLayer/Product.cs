using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CITS_asgmt_4.DataLayer
{
    public class Product
    {
        [Key]
        [Column("productid", TypeName = "int4")]
        
        public int Id { get; }
        [Column("productname", TypeName = "varchar")]
        [MaxLength(40)]
        public string? Name { get; set; }
        [Column("unitprice", TypeName = "int4")]
        public string? UnitPrice { get; set; }
        [Column("quantityperunit", TypeName = "int4")]
        public int QuantityPerUnit { get; set; }
        [Column("unitsinstock", TypeName = "int4")]
        public int  UnitInStock { get; set; }
    }
}
