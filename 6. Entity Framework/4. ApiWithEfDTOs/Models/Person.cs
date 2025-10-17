namespace ApiWithEfDTOs.Models;

public class Person(string name, int age, bool isMarried)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public bool IsMarried { get; set; } = isMarried;

    public ICollection<Adress> Adresses { get; set; } = new List<Adress>();
}