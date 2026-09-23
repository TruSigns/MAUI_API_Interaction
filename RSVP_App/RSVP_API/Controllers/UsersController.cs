using Microsoft.AspNetCore.Mvc;
using RSVP_API.DataAccess;
using RSVP_API.Models;

namespace RSVP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDatabase database;

        public UsersController(AppDatabase database)
        {
            this.database = database;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(
                await database.GetUsersAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            await database.AddUserAsync(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(
            User loginUser)
        {
            var user =
                await database.LoginAsync(
                    loginUser.UserName,
                    loginUser.Password);

            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }
}