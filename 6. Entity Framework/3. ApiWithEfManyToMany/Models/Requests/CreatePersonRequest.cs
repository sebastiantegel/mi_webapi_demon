using System.ComponentModel.DataAnnotations;
using ApiWithEfManyToMany.Validations;

namespace ApiWithEfManyToMany.Models.Requests;

public struct CreatePersonRequest
{
    [Required(ErrorMessage = "Du måste ange ett namn")]
    [StringLength(128, MinimumLength = 2, ErrorMessage = "Du måste ange minst två tecken i namnet")]
    public string Name { get; set; }

    // [Range(1, 130, ErrorMessage = "Åldern måste vara mellan 1 och 130")]
    [AgeValidation(18)]
    public int Age { get; set; }
    public bool IsMarried { get; set; }

    public string Street { get; set; }

    [RegularExpression(@"^\d{5}$", ErrorMessage = "Postnummer måste innehålla fem siffror")]
    public string Zip { get; set; }
    public string City { get; set; }
}

// {
//     "name": "Sebastian",
//     "age": 45,
//     "isMarried": true,
//     "street": "Agatvägen 18",
//     "zip": "11111",
//     "city": "Bromma"
// }