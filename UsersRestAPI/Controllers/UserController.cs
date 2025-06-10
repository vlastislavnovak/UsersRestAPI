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
        public IActionResult get(Guid id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID '{id}' was not found.");
            }

            return Ok(user);
        }

        [HttpGet("getByLastName")]
        public IActionResult getByLastName(String lastName)
        {
            var user = context.Users.FirstOrDefault(u => u.lastName == lastName);

            if (user == null)
            {
                return NotFound($"User with lastname '{lastName}' was not found.");
            }

            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult create(User user)
        {
            if (user.id != Guid.Empty)
            {
                return BadRequest("User id must not be filled.");
            }

            context.Users.Add(user);
            context.SaveChanges();

            return Ok(user);
        }
    }
}
