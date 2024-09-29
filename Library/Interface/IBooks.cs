using Library.Models;

namespace Library.Interface;

public interface IBooks
{
    Task<bool> CreateBook(Books books);
    Task<bool> UpdateBook(Books books);
    Task<bool> DeleteBook(Guid id);
    Task<Books> GetBookById(Guid id);
    Task<IEnumerable<Books>> GetBooks();
    Task<IEnumerable<Books>> GetBooksByFiltrDate(DateTime startDate);
    Task<IEnumerable<Books>> GetBooksAutohorAndCategory();
    Task<IEnumerable<Books>> GetBooksByAuthor(Guid Id);
}