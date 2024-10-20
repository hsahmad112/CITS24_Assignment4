using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS_asgmt_4.DataLayer
{
    [Table("orders", Schema = "public")]
    public class Order
    {
        [Key]
        [Column("orderid", TypeName = "int4")]
        public int Id { get; set; }
        [Column("orderdate", TypeName = "date")]
        public DateTime Date { get; set; } 
        [Column("requireddate", TypeName = "date")]
        public DateTime Required { get; set; }
        [Column("shippeddate", TypeName = "date")]
        public DateTime? ShippedDate { get; set; } 
        [Column("freight", TypeName = "int4")]
        public int Freight { get; set; }
        [Column("shipname", TypeName = "varchar")]
        [MaxLength(40)]
        public string? ShipName { get; set; }
        [Column("shipcity", TypeName = "varchar")]
        [MaxLength(15)]
        public string? ShipCity { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
