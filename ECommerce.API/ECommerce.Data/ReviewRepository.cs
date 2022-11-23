using Data.Entities;
using Microsoft.Extensions.Logging;
using Models;

namespace Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ILogger<ReviewRepository> _logger;
        private readonly CosmeticsContext _context;

        public ReviewRepository(ILogger<ReviewRepository> logger, CosmeticsContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public Review CreateReview(ReviewDTO review)
        {
            Entities.Review reviewEntity = new Entities.Review{UserId = review.UserId, ProductId = review.ProductId, Text = review.Text, Rating = review.Rating};
            _context.Reviews.Add(reviewEntity);
            _context.SaveChanges();
            return reviewEntity;
        }
    }
}