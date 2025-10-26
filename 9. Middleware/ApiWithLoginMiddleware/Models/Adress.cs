namespace ApiWithLoginMiddleware.Models;

public class Adress(string street, string zip, string city)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Street { get; set; } = street;
    public string Zip { get; set; } = zip;
    public string City { get; set; } = city;

    public ICollection<Person> People { get; set; } = new List<Person>();
}