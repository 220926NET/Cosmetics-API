using Models;
using Data.Entities;
using Microsoft.Extensions.Logging;
using System.Web.Helpers;
using WishlistDetail = Data.Entities.WishlistDetail;
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

        public void RegisterNewUser(Models.User userInfo) {
            // Insert new user's info into table, with hashed password
            _context.Add(new Entities.User {
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
        public void CreateWishList(Models.User userInfo) {
            //create a temp wishlist so that the constructor is used to create a HashSet of wishlistDetails
            Entities.Wishlist tempWishlist = new Entities.Wishlist();
            _context.Add(new Entities.Wishlist {
                UserId = userInfo.ID,
                WishlistDetails = tempWishlist.WishlistDetails
            });
            // Save changes made to context to actual DB
            _context.SaveChanges();
            return;
        }

        public bool EmailTaken(string email) {
            // Checks if the given Email exists within the Users table
            if (_context.Users.Any(u => u.Email == email))  return true;
            else    return false;
        }
        public Models.User? VerifyCredentials(string email, string password) {
            Entities.User user = _context.Users.Where(u => u.Email == email).FirstOrDefault()!;

            if (Crypto.VerifyHashedPassword(user.Password, password))   
                return new Models.User(user.Id, user.FirstName, user.LastName, user.Email); 
            else    return null;
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
