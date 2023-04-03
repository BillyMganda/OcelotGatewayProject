using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IUserService _userService;
        public usersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> UserList()
        {
            var userList = _userService.GetUserList();
            return userList;
        }
        [HttpGet("{id}")]
        public User GetUserById(Guid Id)
        {
            return _userService.GetUserById(Id);
        }
        [HttpPost]
        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }
        [HttpPut]
        public User UpdateUser(User user)
        {
            return _userService.UpdateUser(user);
        }
        [HttpDelete("{id}")]
        public bool DeleteUser(Guid id)
        {
            return _userService.DeleteUser(id);
        }
    }
}
