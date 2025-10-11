
using ApiControllers.Models;
using HttpResponses.Models.Requests;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]  // /persons
public class PersonsController : ControllerBase
{
    List<Person> persons = [
        new("Sebastian", 45, true, new("Agatvägen 18", "168 60", "Bromma")),
        new("Hanna", 45, true, new("Drottninggatan 1", "111 10", "Stockholm")),
        new("Astrid", 15, false, new("Stopvägen 64", "164 80", "Bromma")),
        new("Alvar", 15, false, new("Kungsgatan 10", "111 11", "Stockholm"))
    ];

    [HttpGet]
    public ActionResult<List<Person>> GetPersons()
    {
        return Ok(persons);
    }

    [HttpGet]
    [Route("{id}")]  // /persons/{id}
    public ActionResult<Person?> GetPerson(string id)
    {
        try
        {
            Console.WriteLine("Id: " + id);
            Person? found = persons.FirstOrDefault((p) => p.Id == id);

            if (found == null)
            {
                return NotFound("Hittade inte personen du sökte efter");
            }

            return Ok(found);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public ActionResult<Person?> CreatePerson([FromBody] CreatePersonRequest request)
    {
        try
        {
            Person newPerson = new(request.Name, request.Age, request.IsMarried, new(request.Street, request.Zip, request.City));
            persons.Add(newPerson);

            return Created("/persons", newPerson);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}