namespace Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            Deals = new HashSet<Deal>();
            Reviews = new HashSet<Review>();
            WishlistDetails = new HashSet<WishlistDetail>();
        }

        public int ProductId { get; set; }
        public int ApiId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? ColourName { get; set; }
        public string? HexValue { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishlistDetail> WishlistDetails { get; set; }
    }
}
