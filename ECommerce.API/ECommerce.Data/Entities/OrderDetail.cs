using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class OrderDetail
    {
        
        public int OrderDetailID {get; set;}
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
