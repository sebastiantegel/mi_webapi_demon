
using ApiControllersServices.Models;
using ApiControllersServices.Models.Requests;

namespace ApiControllersServices.Services;

public interface IPersonsService
{
    public List<Person> GetPersons();
    public Person? GetPersonById(string id);
    public Person CreatePerson(CreatePersonRequest req);
}

public class PersonsService : IPersonsService
{
    List<Person> persons = [
        new("Sebastian", 45, true, new("Agatvägen 18", "168 60", "Bromma")),
        new("Hanna", 45, true, new("Drottninggatan 1", "111 10", "Stockholm")),
        new("Astrid", 15, false, new("Stopvägen 64", "164 80", "Bromma")),
        new("Alvar", 15, false, new("Kungsgatan 10", "111 11", "Stockholm"))
    ];

    public List<Person> GetPersons()
    {
        return persons.OrderBy(p => p.Name).ToList();
    }

    public Person? GetPersonById(string id)
    {
        Person? found = persons.FirstOrDefault((p) => p.Id == id);

        return found;
    }

    public Person CreatePerson(CreatePersonRequest request)
    {
        Person newPerson = new(request.Name, request.Age, request.IsMarried, new(request.Street, request.Zip, request.City));
        persons.Add(newPerson);

        return newPerson;
    }

}