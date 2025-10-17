
using ApiWithEfDTOs.Models;
using ApiWithEfDTOs.Models.DTOs;
using ApiWithEfDTOs.Models.Requests;
using ApiWithEfDTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithEfDTOs.Controllers;

[ApiController]
[Route("[controller]")]  // /persons
public class PersonsController(IPersonsService service) : ControllerBase
{
    private readonly IPersonsService _service = service;

    [HttpGet]
    public ActionResult<List<PersonDTO>> GetPersons()
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
    public async Task<ActionResult<Person?>> CreatePerson([FromBody] CreatePersonRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // return BadRequest(ModelState);
                return ValidationProblem(ModelState);
            }

            Person newPerson = await _service.CreatePerson(request);

            return Created("/persons", newPerson);
        }
        catch
        {
            throw;
        }
    }
}