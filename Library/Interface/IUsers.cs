using Library.Models;

namespace Library.Interface;

public interface IUsers
{
    Task<bool> CreateUser(Users users);
    Task<Users> GetUserById(Guid id);
    Task<bool> UpdateUser(Users users);
    Task<bool> DeleteUser(Guid id);
    Task<IEnumerable<Users>> GetUsers();
}