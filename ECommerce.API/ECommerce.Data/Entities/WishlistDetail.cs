namespace Data.Entities
{
    public partial class WishlistDetail
    {
        public int DetailId { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }

        public virtual Wishlist IdNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
