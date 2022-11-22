namespace Models
{
    public class WishlistItem
    {
        public int DetailId { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;
    }      

}