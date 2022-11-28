using Data.Entities;
using Models;

namespace Data
{
    public interface IReviewRepository
    {
        public Review CreateReview(ReviewDTO review);
        public Review GetByReviewId(int reviewId);
        public List<Review> GetByProductId(int productId);
        public List<Review> GetByUserId(int userId);
    }
}