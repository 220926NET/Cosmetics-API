using Data.Entities;
using Models;

namespace Data
{
    public interface IReviewRepository
    {
        public Review CreateReview(Review review);
    }
}