using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CITS_asgmt_4.DataLayer

{
    [Table("orderdetails", Schema = "public")]
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderDetail
    {
        [Column("unitprice", TypeName = "int4")]
        public int UnitPrice { get; set; }
        [Column("quantity", TypeName = "int4")]
        public int Quantity { get; set; }
        [Column("discount", TypeName ="int4")]
        public int Discount { get; set; }

        
        public virtual Order Order { get; set; }

        [ForeignKey("Order")]
        [Column("orderid", TypeName ="int4", Order = 1)]
        public int OrderId { get; set; }

        public virtual Product Product{ get; set; }
        [ForeignKey("Product")]
        [Column("productid", TypeName ="int4", Order = 2)]
        public int ProductId { get; set; }


    }
}
