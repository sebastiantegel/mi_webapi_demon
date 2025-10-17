
using ApiWithEfDTOs.Models;
using ApiWithEfDTOs.Models.DTOs;
using ApiWithEfDTOs.Models.Requests;
using ApiWithEfDTOs.Repositories;
using AutoMapper;

namespace ApiWithEfDTOs.Services;

public interface IPersonsService
{
    public IEnumerable<PersonDTO> GetPersons();
    public Person? GetPersonById(string id);
    public Task<Person> CreatePerson(CreatePersonRequest req);
}

public class PersonsService : IPersonsService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonsService(IPersonRepository repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    public IEnumerable<PersonDTO> GetPersons()
    {
        IEnumerable<Person> persons = _repository.GetPersons();

        return _mapper.Map<IEnumerable<PersonDTO>>(persons);
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