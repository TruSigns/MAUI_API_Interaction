using Microsoft.AspNetCore.Mvc;
using RSVP_API.DataAccess;
using RSVP_API.Models;

namespace RSVP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController : ControllerBase
    {
        private readonly AppDatabase database;

        public RSVPController(AppDatabase database)
        {
            this.database = database;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RSVP rsvp)
        {
            await database.AddRSVPAsync(rsvp);

            return Ok(rsvp);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<RSVP>>> GetUserRSVPs(
            int userId)
        {
            return Ok(
                await database.GetUserRSVPsAsync(userId));
        }

        [HttpGet("attending/{userId}")]
        public async Task<ActionResult<List<Event>>> GetAttending(
            int userId)
        {
            return Ok(
                await database.GetAttendingEventsAsync(userId));
        }
    }
}