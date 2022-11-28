using Data;
using Data.Entities;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewRepository _repo;
        private readonly ILogger<AuthController> _logger;

        public ReviewController(IReviewRepository repo, ILogger<AuthController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        
        [HttpPost]
        public ActionResult<Review> Create([FromBody] ReviewDTO review)
        {
            // Check if User model is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Review created = _repo.CreateReview(review);
            return Created($"{created.Id}", created);
        }
        
        [HttpGet("{reviewId}")]
        public ActionResult<Review> GetById(int reviewId)
        {
            try
            {
                return Ok(_repo.GetByReviewId(reviewId));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("product/{productId}")]
        public ActionResult<List<Review>> GetByProductId(int productId)
        {
            return Ok(_repo.GetByProductId(productId));
        }
        
        [HttpGet("user/{userId}")]
        public ActionResult<List<Review>> GetByUserId(int userId)
        {
            return Ok(_repo.GetByUserId(userId));
        }
        
        [HttpPut("{reviewId}")]
        public ActionResult Update(int reviewId)
        {
            return Ok();
        }

        [HttpDelete("{reviewId}")]
        public ActionResult Delete(int reviewId)
        {
            return Ok();
        }
        
    }
}