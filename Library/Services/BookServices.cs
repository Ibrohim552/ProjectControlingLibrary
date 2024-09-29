using Dapper;
using Library.Interface;
using Library.Models;
using Npgsql;

namespace Library.Services;

public class BookServices:IBooks
{
    public async Task<bool> CreateBook(Books books)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.insertBook, books) > 0;
        }
    }

    public async Task<bool> UpdateBook(Books books)
    {
       using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.UpdateBook, books) > 0;
        }   
    }

    public async Task<bool> DeleteBook(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteBookById, new {id}) > 0;
        }
    }

    public async Task<Books> GetBookById(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<Books>(SqlCommands.GetBookById, new {id});
        }
    }

    public async Task<IEnumerable<Books>> GetBooks()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Books>(SqlCommands.GetAllBooks);
        }
    }

    public async Task<IEnumerable<Books>> GetBooksByFiltrDate(DateTime startDate)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return await connection.QueryAsync<Books>(SqlCommands.GetBookByFiltrDate, new { startDate });
        }
    }

    public async Task<IEnumerable<Books>> GetBooksAutohorAndCategory()
    {
        using (NpgsqlConnection connection =new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return await connection.QueryAsync<Books>(SqlCommands.GetBookAutohorAndCategory);
        }
    }

    public async Task<IEnumerable<Books>> GetBooksByAuthor(Guid authorId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return await connection.QueryAsync<Books>(SqlCommands.GetBookByAuthor
                , new { authorId });
        }
    }
}