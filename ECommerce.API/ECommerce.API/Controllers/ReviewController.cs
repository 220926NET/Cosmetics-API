using Data;
using Data.Entities;
using Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewRepository _repo;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository repo, ILogger<AuthController> logger, IMapper mapper)
        {
            this._repo = repo;
            this._logger = logger;
            this._mapper = mapper;
        }

        
        [HttpPost]
        public ActionResult<ReviewDTO> Create([FromBody] ReviewRequest review)
        {
            // Check if User model is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Review created = _repo.CreateReview(_mapper.Map<Review>(review));
            return Created($"{created.Id}", _mapper.Map<ReviewDTO>(created));
        }
        
        [HttpGet("{reviewId}")]
        public ActionResult<ReviewDTO> GetById(int reviewId, bool includeUser = false, bool includeProduct = false)
        {
            try
            {
                Review review = _repo.GetByReviewId(reviewId, includeUser, includeProduct);
                ReviewDTO dto = _mapper.Map<ReviewDTO>(review);
                return Ok(dto);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("product/{productId}")]
        public ActionResult<List<ReviewDTO>> GetByProductId(int productId, bool includeUser = false, bool includeProduct = false)
        {
            try
            {
                List<Review> reviewList = _repo.GetByProductId(productId, includeUser, includeProduct);
                List<ReviewDTO> dtoList = reviewList.Select(i => _mapper.Map<ReviewDTO>(i)).ToList();
                return Ok(dtoList);
            }
            catch
            {
                return NotFound();
            }
        }
        
        [HttpGet("user/{userId}")]
        public ActionResult<List<ReviewDTO>> GetByUserId(int userId, bool includeUser = false, bool includeProduct = false)
        {
            try
            {
                List<Review> reviewList = _repo.GetByUserId(userId, includeUser, includeProduct);
                List<ReviewDTO> dtoList = reviewList.Select(i => _mapper.Map<ReviewDTO>(i)).ToList();
                return Ok(dtoList);
            }
            catch
            {
                return NotFound();
            }
        }
        
        /*
        [HttpPut("{reviewId}")]
        public ActionResult Update(int reviewId)
        {
            return Ok();
        }
        */

        [HttpDelete("{reviewId}")]
        public ActionResult Delete(int reviewId)
        {
            if (_repo.Delete(reviewId))
                return NoContent();
            return NotFound();
        }
    }
}