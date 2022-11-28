using Data.Entities;
using Models;

namespace Data
{
    public interface IReviewRepository
    {
        public Review CreateReview(Review review);
        public Review GetByReviewId(int reviewId);
        public List<Review> GetByProductId(int productId);
        public List<Review> GetByUserId(int userId);
        public bool Delete(int reviewId);
    }
}