namespace Data.Entities
{
    public partial class Deal
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Product { get; set; }

        public virtual Product ProductNavigation { get; set; } = null!;
    }
}
