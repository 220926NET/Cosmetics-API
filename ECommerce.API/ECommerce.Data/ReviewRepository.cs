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

        // Returns the Primary Product Id associated with the given API Id
        public int ApiIdToPrimaryProductId(int apiId)
        {
            return _context.Products.Where(i => i.ApiId == apiId).First().ProductId;
        }

        // Returns the Primary Product Id associated with the given Product Id
        public int ProductIdToPrimaryProductId(int productId)
        {
            return ApiIdToPrimaryProductId(_context.Products.Where(i => i.ProductId == productId).First().ApiId);
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

        public List<Review> GetByApiId(int apiId, bool includeUser = false, bool includeProduct = false)
        {
            HashSet<int> productIdSet = _context.Products
                .Where(product => product.ApiId == apiId)
                .Select(product => product.ProductId)
                .ToHashSet();

            IQueryable<Review> result = _context.Reviews
                .Where(review => productIdSet.Contains(review.ProductId));

            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.ToList();
        }

        public List<Review> GetByProductId(int productId, bool includeUser = false, bool includeProduct = false)
        {
            var result = _context.Reviews.Where(i => i.ProductId == productId);
            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.ToList();
        }

        public List<Review> GetByUserId(int userId, bool includeUser = false, bool includeProduct = false)
        {
            var result = _context.Reviews.Where(i => i.UserId == userId);
            if (includeUser)
                result = result.Include(i => i.User);
            if (includeProduct)
                result = result.Include(i => i.Product);
            return result.ToList();
        }

        public bool Delete(int reviewId)
        {
            var entityQuery = _context.Reviews.Where(i => i.Id == reviewId);
            if (entityQuery.Count() == 0)
                return false;
            var entity = entityQuery.First();
            _context.Reviews.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}