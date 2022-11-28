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

        public Review GetByReviewId(int reviewId, bool includeUser = false, bool includeProduct = false)
        {
            var result = _context.Reviews.Where(i => i.Id == reviewId);
            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.First();
        }

        public List<Review> GetByProductId(int productId, bool includeUser = false, bool includeProduct = false)
        {
            //return _context.Reviews.Where(i => i.ProductId == productId).Include(i => i.User).Include(i => i.Product).ToList();

            var result = _context.Reviews.Where(i => i.ProductId == productId);
            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.ToList();
        }

        public List<Review> GetByUserId(int userId, bool includeUser = false, bool includeProduct = false)
        {
            //return _context.Reviews.Where(i => i.UserId == userId).Include(i => i.User).Include(i => i.Product).ToList();

            var result = _context.Reviews.Where(i => i.UserId == userId);
            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.ToList();
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