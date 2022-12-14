using Models;

namespace Data
{
    public interface IRepository
    {
        /* Create */
        void RegisterNewUser(User userInfo);
        void CreateWishList(User userInfo);
        void CreateWishlistItem(int wishlistId, int productId);

        /* Read */
        bool EmailTaken(string email);
        User? VerifyCredentials(string email, string password);
        Models.Wishlist GetWishlist(int userId);

        /* Update */
        void ReduceInventoryById(int productId, int purchaseQuantity, int userId);

        /* Destroy */
        void DeleteWishListItem(int detailId);
    }
}