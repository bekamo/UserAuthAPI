using BasicAuthAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicAuthAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<UserRole[]> GetRolesByUsername(string username);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(int id);
    }
}