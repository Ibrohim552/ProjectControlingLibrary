using Dapper;
using Library.Interface;
using Library.Models;
using Npgsql;

namespace Library.Services;

public class BookRentalsServices: IBookRentals
{
    public async Task<bool> CreateBookRentals(BookRentals bookRentals)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.InsertBookRental, bookRentals) > 0;
        }
    }

    public async Task<bool> UpdateBookRentals(BookRentals bookRentals)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.UpdateBookRental, bookRentals) > 0;
        }
    }

    public async Task<bool> DeleteBookRentals(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteBookRentalById, new {id}) > 0;
        }
    }

    public async Task<BookRentals> GetBookRentalsById(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<BookRentals>(SqlCommands.GetBookRentalById, new {id});
        }
    }

    public async Task<IEnumerable<BookRentals>> GetBookRentals()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<BookRentals>(SqlCommands.GetAllBookRentals);
        }
    }

    public async Task<IEnumerable<BookRentals>> GetBookRentalsByUserId(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return await connection.QueryAsync<BookRentals>(SqlCommands.GetBookRentalsByUserId, new {id});
        }   
    }
}