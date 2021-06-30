using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Web_API_2.Models;
using Web_API_2.Services;
namespace Web_API_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
       private readonly IPersonService _personService;
        public PersonController(IPersonService personService){
            _personService = personService;
        }
        // GET all action
        [HttpGet("/people")]
        public ActionResult<List<PersonModel>> GetAll() =>
        _personService.GetAll();
        // GET action
        [HttpGet("/person/{id}")]
        public ActionResult<PersonModel> Get(int id)
        {
            var person = _personService.Get(id);
            if (person == null){    
                var NotFound = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                return NotFound;
            }
            return person;
        }
        // POST action
        [HttpPost("/person")]
        public IActionResult Create(PersonModel person)
        {
            if (person is null)
            {
                var NotFound = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                return NotFound;
            }
            _personService.Add(person);
            CreatedAtAction(nameof(person), new { id = person.Id }, person);
            return Ok(person);
        }
        // PUT action
        [HttpPut("/person/{id}")]
        public IActionResult Update(int id, PersonModel person)
        {
            if (id != person.Id)
            {
                var BadRequest = new BadRequestObjectResult(new { message = "400 Bad Request", currentDate = DateTime.Now });
                return BadRequest;
            }
            var existingPerson = _personService.Get(id);
            if (existingPerson is null)
            {
                var NotFound = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                return NotFound;
            }
            _personService.Update(person);
            // var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
            return Ok(person);
        }
        // DELETE action
        [HttpDelete("/person/{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.Get(id);
            if (person is null)
            {
                var NotFound = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
                return NotFound;
            }
            _personService.Delete(id);
            var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
            return result;
        }
        [HttpPost("/person-filter")]
        public List<PersonModel> Filters(FilterPersonModel model)
        {
            return _personService.Filters(model);
        }
    }
}
