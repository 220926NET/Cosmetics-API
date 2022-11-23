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
        public ActionResult<Review> Create([FromBody] Review review)
        {
            // Check if User model is valid
            //if (!ModelState.IsValid)
                //return BadRequest(ModelState);

            //var created = _repo.CreateReview(review);
            //return Created($"{created.Id}", created);
            return Ok();
        }
        /*
        [HttpGet("{reviewId}")]
        public ActionResult<List<Review>> GetById(int reviewId)
        {
            return Ok();
        }

        [HttpGet("product/{productId}")]
        public ActionResult<List<Review>> GetByProductId(int productId)
        {
            return Ok();
        }
        
        [HttpGet("user/{userId}")]
        public ActionResult<List<Review>> GetByUserId(int userId)
        {
            return Ok();
        }
        */
        
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