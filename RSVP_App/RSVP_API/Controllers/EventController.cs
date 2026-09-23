using Microsoft.AspNetCore.Mvc;
using RSVP_API.DataAccess;
using RSVP_API.Models;

namespace RSVP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDatabase database;

        public EventsController(AppDatabase database)
        {
            this.database = database;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get()
        {
            return Ok(
                await database.GetEventsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            var eventItem =
                await database.GetEventAsync(id);

            if (eventItem == null)
                return NotFound();

            return Ok(eventItem);
        }

        [HttpGet("hosted/{userId}")]
        public async Task<ActionResult<List<Event>>> GetHosted(
            int userId)
        {
            return Ok(
                await database.GetHostedEventsAsync(userId));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Event eventItem)
        {
            await database.AddEventAsync(eventItem);

            return Ok(eventItem);
        }
    }
}