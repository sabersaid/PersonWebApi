

using WebApiTest.Data;
using WebApiTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;
        public PersonController(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var persons = await _AppDbContext.Person.ToListAsync();
            //TODO use Automapper to add age
            return Ok(persons);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(Person person)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime birthDate = person.BirthDate.Date;
            DateTime nowDate = DateTime.Now;

            TimeSpan span = nowDate - birthDate;
            int years = (zeroTime + span).Year - 1;
            if (years > 150) return BadRequest("not valid");
            else {
                _AppDbContext.Person.Add(person);
                await _AppDbContext.SaveChangesAsync();
                return Ok(person);
            }
          
        }


    }
}