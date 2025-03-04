namespace BlogAPI.Domain.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CategoryName { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}
