namespace ApiValidation.Models;

public class Person(string name, int age, bool isMarried, Adress adress)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public bool IsMarried { get; set; } = isMarried;
    public Adress Adress { get; set; } = adress;
}