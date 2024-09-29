using Library.Models;

namespace Library.Interface;

public interface IAuthor
{
    Task<bool> CreateAuthor(Authors author);
    Task<bool> UpdateAuthor(Authors author);
    Task<bool> DeleteAuthor(Guid id);
    Task<Authors> GetAuthorById(Guid id);
    Task<IEnumerable<Authors>> GetAuthors();
}