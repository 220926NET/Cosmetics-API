using Data.Entities;
using Models;

namespace Data
{
    public interface IReviewRepository
    {
        public Review CreateReview(Review review);
        public int ApiIdToProductId(int apiId);
        public Review GetByReviewId(int reviewId, bool includeUser, bool includeProduct);
        public List<Review> GetByProductId(int productId, bool includeUser, bool includeProduct);
        public List<Review> GetByUserId(int userId, bool includeUser, bool includeProduct);
        
        public bool Delete(int reviewId);
    }
}