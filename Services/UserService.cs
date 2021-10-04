using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicAuthAPI.Models;

namespace BasicAuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;

        public UserService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() =>
                 _context.Users.SingleOrDefault(x => x.UserName == username && x.Password == password));

            if (user == null)
                return null;

            // remove user password
            user.Password = null;
            return user;
        }

        public async Task<UserRole[]> GetRolesByUsername(string username)
        {
            var userRoles = await Task.Run(() =>
                 _context.UserRoles.Where(o => o.UserName == username));

            if (userRoles == null)
                return null;

            return userRoles.ToArray();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _context.Users);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
