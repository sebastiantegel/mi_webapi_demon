
using ApiWithEfBasics.Contexts;
using ApiWithEfBasics.Models;

namespace ApiWithEfBasics.Repositories;

public interface IPersonRepository
{
    public IEnumerable<Person> GetPersons();
    public Person? GetPersonById(string id);
    public Task<Person> CreatePerson(Person personToSave);
}

public class PersonRepository(ApplicationDbContext context) : IPersonRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Person> CreatePerson(Person personToSave)
    {
        try
        {
            var result = await _context.People.AddAsync(personToSave);
            int changes = await _context.SaveChangesAsync();

            if (changes > 0)
            {
                return result.Entity;
            }

            throw new Exception("Could not add person");
        }
        catch
        {
            throw;
        }
    }

    public Person? GetPersonById(string id)
    {
        _context.Database.EnsureCreated();
        return _context.People.Find(id);
    }

    public IEnumerable<Person> GetPersons()
    {
        _context.Database.EnsureCreated();
        return _context.People.ToList();
    }
}