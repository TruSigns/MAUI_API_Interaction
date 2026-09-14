using MAUIWebAPI.Models;
using MAUIWebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace MAUIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new PersonData().GetPeople();
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var personData = new PersonData();

            personData.SavePerson(value);
        }
    }
}