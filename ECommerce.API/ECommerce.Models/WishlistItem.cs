namespace Models
{
    public class WishlistItem
    {
        public int DetailId { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }

        public ProductDetailsDto Product { get; set; } = null!;

        public WishlistItem(int dId, int id, int pId, ProductDetailsDto p)
        {
            DetailId = dId;
            Id = id;
            ProductId = pId;
            Product = p;
        }
    }      

}