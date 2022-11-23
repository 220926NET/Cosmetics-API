using Data.Entities;
using Microsoft.Extensions.Logging;

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

        public Review CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }
    }
}