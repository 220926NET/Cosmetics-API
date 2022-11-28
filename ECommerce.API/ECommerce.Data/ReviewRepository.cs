using Data.Entities;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

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

        public Review GetByReviewId(int reviewId)
        {
            //_context.Entry(post).Reference(p => p.Blog).Load();
            return _context.Reviews.Where(i => i.Id == reviewId).Include(i => i.User).Include(i => i.Product).First();
        }

        public List<Review> GetByProductId(int productId)
        {
            return _context.Reviews.Where(i => i.ProductId == productId).ToList();
        }

        public List<Review> GetByUserId(int userId)
        {
            return _context.Reviews.Where(i => i.UserId == userId).ToList();
        }
    }
}