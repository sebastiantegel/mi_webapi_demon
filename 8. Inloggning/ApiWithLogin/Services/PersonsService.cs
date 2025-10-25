
using ApiWithLogin.Models;
using ApiWithLogin.Models.Requests;
using ApiWithLogin.Repositories;

namespace ApiWithLogin.Services;

public interface IPersonsService
{
    public IEnumerable<Person> GetPersons();
    public Person? GetPersonById(string id);
    public Task<Person> CreatePerson(CreatePersonRequest req);
}

public class PersonsService : IPersonsService
{
    private readonly IPersonRepository _repository;

    public PersonsService(IPersonRepository repo)
    {
        _repository = repo;
    }

    public IEnumerable<Person> GetPersons()
    {
        return _repository.GetPersons();
    }

    public Person? GetPersonById(string id)
    {
        return _repository.GetPersonById(id);
    }

    public async Task<Person> CreatePerson(CreatePersonRequest request)
    {
        Person newPerson = new(request.Name, request.Age, request.IsMarried);

        Person createdPerson = await _repository.CreatePerson(newPerson);

        return createdPerson;
    }

}