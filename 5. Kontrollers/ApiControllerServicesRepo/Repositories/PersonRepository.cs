
using ApiControllerServicesRepo.Models;

namespace ApiControllerServicesRepo.Repositories;

public interface IPersonRepository
{
    public List<Person> GetPersons();
    public Person? GetPersonById(string id);
    public bool CreatePerson(Person personToSave);
}

public class PersonRepository : IPersonRepository
{
    List<Person> persons = [
        new("Sebastian", 45, true, new("Agatvägen 18", "168 60", "Bromma")),
        new("Hanna", 45, true, new("Drottninggatan 1", "111 10", "Stockholm")),
        new("Astrid", 15, false, new("Stopvägen 64", "164 80", "Bromma")),
        new("Alvar", 15, false, new("Kungsgatan 10", "111 11", "Stockholm"))
    ];

    public bool CreatePerson(Person personToSave)
    {
        try
        {
            persons.Add(personToSave);

            return true;
        }
        catch
        {
            throw;
        }
    }

    public Person? GetPersonById(string id)
    {
        return persons.FirstOrDefault((p) => p.Id == id);
    }

    public List<Person> GetPersons()
    {
        return persons;
    }
}