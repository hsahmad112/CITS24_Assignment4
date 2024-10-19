using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS_asgmt_4.DataLayer
{
    public class Order
    {
        [Key]
        [Column("orderid", TypeName = "int4")]
        public int Id { get; }
        [Column("orderdate", TypeName = "date")]
        public DateTime OrderdDate { get; set; } //changed name to reflect purpose
        [Column("requireddate", TypeName = "date")]
        public DateTime RequiredDate { get; set; }
        [Column("shippeddate", TypeName = "date")]
        public DateTime ShippedDate { get; set; } //changed name to reflect purpose
        [Column("freight", TypeName = "int4")]
        public int Freight { get; set; }
        [Column("shipname", TypeName = "varchar")]
        [MaxLength(40)]
        public string? ShipName { get; set; }
        [Column("shipcity", TypeName = "varchar")]
        [MaxLength(15)]
        public string? ShipCity { get; set; }
    }
}
