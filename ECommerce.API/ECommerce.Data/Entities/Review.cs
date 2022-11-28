namespace Data.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Data.Entities.User User { get; set; } = null!;
    }
}
