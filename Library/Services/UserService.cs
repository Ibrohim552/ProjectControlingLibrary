using Dapper;
using Library.Interface;
using Library.Models;
using Npgsql;

namespace Library.Services;

public class UserService:IUsers
{
    public async Task<bool> CreateUser(Users users)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
           await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.InsertUser, users) > 0;
        }
    }

    public async Task<Users> GetUserById(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<Users>(SqlCommands.GetUserById, new {id});
        }
    }

    public async Task<bool> UpdateUser(Users users)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.UpdateUser, users) > 0;
        }
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteUserById, new {id}) > 0;
        }
    }

    public async Task<IEnumerable<Users>> GetUsers()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Users>(SqlCommands.GetAllUsers);
        }
    }
}