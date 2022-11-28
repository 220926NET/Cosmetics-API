namespace Models;

public class ReviewDTO
{
        public class ProductDTO
        {
                public int ProductId { get; set; }
                public int ApiId { get; set; }
                public string ProductName { get; set; } = String.Empty;
                public string ProductType { get; set; } = String.Empty;
                public string Brand { get; set; } = String.Empty;
                public decimal Price { get; set; }
                public string Description { get; set; } = String.Empty;
                public string Image { get; set; } = String.Empty;
                public string ColourName { get; set; } = String.Empty;
                public string HexValue { get; set; } = String.Empty;
        }
        public class UserDTO
        {
                public int Id { get; set; }
                public string FirstName { get; set; } = String.Empty;
                public string LastName { get; set; } = String.Empty;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; } = String.Empty;
        public int Rating { get; set; }
        public UserDTO? User { get; set; }
        public ProductDTO? Product { get; set; }
}