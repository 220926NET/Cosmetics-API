namespace Data.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int Purchaser { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }

        public virtual User PurchaserNavigation { get; set; } = null!;
    }
}
