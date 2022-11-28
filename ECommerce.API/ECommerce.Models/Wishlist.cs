

namespace Models
{
    public class Wishlist
    {
        public int id { get; set; }
        public int userId { get; set; }
        public HashSet<WishlistItem>? wishItems { get; set; }

        public Wishlist(int Id, int UserId, HashSet<WishlistItem> WishlistDetails)
        {
            id= Id;
            userId= UserId;
            wishItems= WishlistDetails;
        }

    }
}