using Dapper;
using Library.Interface;
using Library.Models;
using Npgsql;

namespace Library.Services;

public class AuthorServices:IAuthor
{
    public async Task<bool> CreateAuthor(Authors author)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.InsertAuthor,author) > 0;
        }
    }

    public async Task<bool> UpdateAuthor(Authors author)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.UpdateAuthor, author) > 0;
        }
    }

    public async Task<bool> DeleteAuthor(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteAuthorById, new {id}) > 0;
        }
    }

    public async Task<Authors> GetAuthorById(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<Authors>(SqlCommands.GetAuthorById, new {id});
        }
    }

    public async Task<IEnumerable<Authors>> GetAuthors()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Authors>(SqlCommands.GetAllAuthors);
        }
    }
}