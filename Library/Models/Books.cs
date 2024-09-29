namespace Library.Models;

public class Books
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
}
