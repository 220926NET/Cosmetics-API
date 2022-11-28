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

        public Review CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return _context.Reviews.Where(i => i.Id == review.Id).Include(i => i.User).Include(i => i.Product).First();
        }

        public Review GetByReviewId(int reviewId)
        {
            //_context.Entry(post).Reference(p => p.Blog).Load();
            return _context.Reviews.Where(i => i.Id == reviewId).Include(i => i.User).Include(i => i.Product).First();
        }

        public List<Review> GetByProductId(int productId)
        {
            return _context.Reviews.Where(i => i.ProductId == productId).Include(i => i.User).Include(i => i.Product).ToList();
        }

        public List<Review> GetByUserId(int userId)
        {
            return _context.Reviews.Where(i => i.UserId == userId).Include(i => i.User).Include(i => i.Product).ToList();
        }

        public bool Delete(int reviewId)
        {
            var entity = _context.Reviews.First(i => i.Id == reviewId);
            if (entity is null)
                return false;
            _context.Reviews.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}