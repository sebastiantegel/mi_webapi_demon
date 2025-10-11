
using ApiControllerServicesRepo.Models;
using ApiControllerServicesRepo.Models.Requests;
using ApiControllerServicesRepo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllerServicesRepo.Controllers;

[ApiController]
[Route("[controller]")]  // /persons
public class PersonsController(IPersonsService service) : ControllerBase
{
    private readonly IPersonsService _service = service;

    [HttpGet]
    public ActionResult<List<Person>> GetPersons()
    {
        return Ok(_service.GetPersons());
    }

    [HttpGet]
    [Route("{id}")]  // /persons/{id}
    public ActionResult<Person?> GetPerson(string id)
    {
        try
        {
            Person? found = _service.GetPersonById(id);

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
            Person newPerson = _service.CreatePerson(request);

            return Created("/persons", newPerson);
        }
        catch
        {
            throw;
        }
    }
}