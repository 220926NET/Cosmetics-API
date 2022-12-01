using Models;
using Data.Entities;
using Microsoft.Extensions.Logging;
using System.Web.Helpers;
using WishlistDetail = Data.Entities.WishlistDetail;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
// using System.Data.SqlClient;
// using System.Linq;
// using System.Net.Http.Headers;
// using System.Text;
// using System.Threading.Tasks;
// using System;
// using System.Collections.Generic;

namespace Data
{
    public class SQLRepository : IRepository
    {
        private readonly ILogger<SQLRepository> _logger;
        private readonly CosmeticsContext _context;

        public SQLRepository(ILogger<SQLRepository> logger, CosmeticsContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public void RegisterNewUser(Models.User userInfo)
        {
            // Insert new user's info into table, with hashed password
            _context.Add(new Entities.User
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                Password = Crypto.HashPassword(userInfo.Password)
            });

            // Save changes made to context to actual DB
            _context.SaveChanges();
            return;
        }
        //create a new wishlist
        public void CreateWishList(Models.User userInfo)
        {
            //create a temp wishlist so that the constructor is used to create a HashSet of wishlistDetails
            Entities.Wishlist tempWishlist = new Entities.Wishlist();
            _context.Add(new Entities.Wishlist
            {
                UserId = userInfo.ID,
                WishlistDetails = tempWishlist.WishlistDetails
            });
            // Save changes made to context to actual DB
            _context.SaveChanges();
            return;
        }

        public void CreateWishlistItem(int wishlistId, int productId)
        {
            //Post to the wishlistDetails Database
            _context.Add(new Entities.WishlistDetail
            {
                Id = wishlistId,
                ProductId = productId
            });
            _context.SaveChanges();
        }

        //Get Commands

        public bool EmailTaken(string email)
        {
            // Checks if the given Email exists within the Users table
            if (_context.Users.Any(u => u.Email == email)) return true;
            else return false;
        }
        public Models.User? VerifyCredentials(string email, string password)
        {
            Entities.User user = _context.Users.Where(u => u.Email == email).FirstOrDefault()!;

            if (Crypto.VerifyHashedPassword(user.Password, password))
                return new Models.User(user.Id, user.FirstName, user.LastName, user.Email);
            else return null;
        }

        public Models.Wishlist GetWishlist(int uId)
        {
           
            //create a model of wishlist items
            HashSet<Models.WishlistItem> wishlistSet = new HashSet<Models.WishlistItem>();

            Models.Wishlist mWishList = new Models.Wishlist(0,0,wishlistSet);
            //eager loading

            if (_context.Wishlists.Any(w => w.UserId == uId))
            {
                var dbWishlist = _context.Wishlists
                    .Where(w => w.UserId == uId)
                    .Include(wl => wl.WishlistDetails)
                    .ThenInclude(wld => wld.Product)
                    .FirstOrDefault();


                //if (_context.Wishlists.Any(w => w.UserId == uId))
                //{
                //    var dbWishlist = _context.Wishlists
                //        .Include(wl => wl.WishlistDetails)
                //        .ThenInclude(wld => wld.Product);


                    if (dbWishlist != null)
                {
                    if(dbWishlist.WishlistDetails.Count > 0)
                    {
                        foreach(WishlistDetail detail in dbWishlist.WishlistDetails)
                        {
                            
                            Models.Product mProduct = new Models.Product(detail.Product.ProductId, detail.Product.ProductName, detail.Product.Inventory, detail.Product.Price, detail.Product.Description, detail.Product.Image, detail.Product.ColourName, detail.Product.HexValue);
                            Models.WishlistItem itemToAdd = new Models.WishlistItem(detail.DetailId, detail.Id,detail.ProductId, mProduct);
                            wishlistSet.Add(itemToAdd);
                        }

                    }
                    mWishList.id = dbWishlist.Id;
                    mWishList.userId = dbWishlist.UserId;

                }
            }
            //return  a model
            return mWishList;
        }


        //Destroy Stuff
        public void DeleteWishListItem(int detailId)
        {
            //This method does not check to see if the item exists in the DB before going to delete it
            //This saves time, but error handling will need to implemented on the front end to ensure
            //only existing wishlist items get called to be deleted
            WishlistDetail wishItem = new WishlistDetail { DetailId = detailId };
            _context.WishlistDetails.Attach(wishItem);
            _context.WishlistDetails.Remove(wishItem);
            _context.SaveChanges();
        }


        //Updated quantity for purchase
        public void ReduceInventoryById(int productId, int purchaseQuantity)
        {
            var product = _context.Products.FirstOrDefault(item => item.ProductId == productId);
            if(product != null){
                product.Inventory = product.Inventory - purchaseQuantity;
                _context.SaveChanges();
            }
            
        }


        /*
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            List<Product> products = new List<Product>();

            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = "SELECT [ProductId], [ProductName], [ProductQuantity], [ProductPrice], [ProductDescription],[ProductImage] FROM [ecd].[Products];";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int quant = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                string desc = reader.GetString(4);
                string image = reader.GetString(5);

                products.Add(new Product(id, name, quant, price, desc, image));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllProductsAsync");

            return products;
        }*/

        /*
        public async Task<Product> GetProductByIdAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = @"SELECT * FROM [ecd].[Products] WHERE [ProductId] = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@ID", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            Product tmp = new Product();
            while (reader.Read())
            {
                tmp.id = id;
                tmp.name = reader.GetString(1);
                tmp.quantity = reader.GetInt32(2);
                tmp.price = reader.GetDecimal(3);
                tmp.description = reader.GetString(4);
                tmp.image = reader.GetString(5);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetProductByIdAsync");

            return tmp;
        }*/

        /*
        public async Task ReduceInventoryByIdAsync(int id, int purchased)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = @"UPDATE [ecd].[Products] 
                               SET [ProductQuantity] = (
                                    SELECT [ProductQuantity] 
                                    FROM [ecd].[Products] 
                                    WHERE [ProductId] = @ID) - @P 
                               WHERE [ProductId] = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@P", purchased);

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            _logger.LogInformation("Executed ReduceInventoryAsync");
        }*/
    }   
}
