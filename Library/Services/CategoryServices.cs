using Dapper;
using Library.Interface;
using Library.Models;
using Npgsql;

namespace Library.Services;

public class CategoryServices:ICategory
{
    public async Task<bool> CreateCategory(Categories categories)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.InsertCategory, categories) > 0;
        }
    }

    public async Task<bool> UpdateCategory(Categories categories)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.UpdateCategory, categories) > 0;
        }
    }

    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteCategoryById, new {categoryId}) > 0;
        }
    }

    public async Task<Categories> GetCategoryById(Guid categoryId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<Categories>(SqlCommands.GetCategoryById, new {categoryId});
        }
    }

    public async Task<IEnumerable<Categories>> GetAllCategories()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Categories>(SqlCommands.GetAllCategories);
        }
    }
}