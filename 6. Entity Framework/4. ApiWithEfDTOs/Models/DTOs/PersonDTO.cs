namespace ApiWithEfDTOs.Models.DTOs;

public class PersonDTO
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public ICollection<AdressDTO> Adresses { get; set; } = new List<AdressDTO>();
}