namespace BlogAPI.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;

        //Post category 1-n 
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //Post Comment  1-n
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
