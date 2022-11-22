

namespace Models
{
    public class Wishlist
    {
        public int id { get; set; }
        public int userId { get; set; }
        public List<WishlistItem>? wishItems { get; set; }

    }
}