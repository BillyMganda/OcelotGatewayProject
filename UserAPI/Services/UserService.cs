using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _dbContext;
        public UserService(UserDbContext context)
        {
            _dbContext = context;
        }

        public User AddUser(User product)
        {
            var result = _dbContext.Users.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(Guid Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            if(filteredData != null)
            {
                _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserById(Guid id)
        {
            return _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault()!;
        }

        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        public User UpdateUser(User product)
        {
            var result = _dbContext.Users.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
