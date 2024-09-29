using Library.Models;

namespace Library.Interface;

public interface IBookRentals
{
    Task<bool> CreateBookRentals(BookRentals bookRentals);
    Task<bool> UpdateBookRentals(BookRentals bookRentals);
    Task<bool> DeleteBookRentals(Guid id);
    Task<BookRentals> GetBookRentalsById(Guid id);
    Task<IEnumerable<BookRentals>> GetBookRentals();
    Task<IEnumerable<BookRentals>> GetBookRentalsByUserId(Guid Id);
}