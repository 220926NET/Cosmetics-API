namespace Models;

public class PostReviewDTO
{
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
}