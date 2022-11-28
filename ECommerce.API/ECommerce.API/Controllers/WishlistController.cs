using API.Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Data.Entities;

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


        // GET api/<WishlistController>/userid/5
        [HttpGet("userId/{id}")]
        public Models.Wishlist Get(int id)
        {
            return _repo.GetWishlist(id);
        }

        // POST api/<WishlistController>
        [HttpPost]
        public void Post(Models.User userInfo)
        {
            _repo.CreateWishList(userInfo);
        }

        // POST api/<WishlistController>
        [HttpPost("/{wishlistId}/wishlistItem/{productId}")]
        public void Post(int wishlistId, int productId)
        {
            _repo.CreateWishlistItem(wishlistId, productId);
        }

        // DELETE api/<WishlistController>/5
        [HttpDelete("/wishlistItem/{detailId}")]
        public void Delete(int detailId)
        {
            _repo.DeleteWishListItem(detailId);
        }
    }
}
