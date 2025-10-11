
using ApiControllerServicesRepo.Models;
using ApiControllerServicesRepo.Models.Requests;
using ApiControllerServicesRepo.Repositories;

namespace ApiControllerServicesRepo.Services;

public interface IPersonsService
{
    public List<Person> GetPersons();
    public Person? GetPersonById(string id);
    public Person CreatePerson(CreatePersonRequest req);
}

public class PersonsService : IPersonsService
{
    private readonly IPersonRepository _repository;

    public PersonsService(IPersonRepository repo)
    {
        _repository = repo;
    }

    public List<Person> GetPersons()
    {
        return _repository.GetPersons();
    }

    public Person? GetPersonById(string id)
    {
        return _repository.GetPersonById(id);
    }

    public Person CreatePerson(CreatePersonRequest request)
    {
        Person newPerson = new(request.Name, request.Age, request.IsMarried, new(request.Street, request.Zip, request.City));

        bool success = _repository.CreatePerson(newPerson);

        if (success)
        {
            return newPerson;
        }

        throw new Exception("Could not add user to the data source");
    }

}