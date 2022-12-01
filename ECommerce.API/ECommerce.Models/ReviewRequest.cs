namespace Models;

public class ReviewRequest
{
        public int UserId { get; set; }
        public int ApiId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
}