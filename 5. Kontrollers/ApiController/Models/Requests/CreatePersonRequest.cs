namespace HttpResponses.Models.Requests;

public struct CreatePersonRequest
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsMarried { get; set; }

    public string Street { get; set; }
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