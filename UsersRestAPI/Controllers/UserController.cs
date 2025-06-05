using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersRestAPI.Data;
using UsersRestAPI.Models;

namespace UsersRestAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext context;

        public UserController(ApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet("get")]
        public IActionResult GetUser(Guid id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID '{id}' was not found.");
            }

            return Ok(user);
        }

        [HttpGet("getByLastName")]
        public IActionResult GetUserByLastName(String lastName)
        {
            var user = context.Users.FirstOrDefault(u => u.lastName == lastName);

            if (user == null)
            {
                return NotFound($"User with lastname '{id}' was not found.");
            }

            return Ok(user);
        }
    }
}
