using API.Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<AuthController> _logger;

        public WishlistController(IRepository repo, ILogger<AuthController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        // GET: api/<WishlistController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WishlistController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WishlistController>
        [HttpPost]
        public void Post(User userInfo)
        {
            _repo.CreateWishList(userInfo);
        }

        // PUT api/<WishlistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WishlistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
