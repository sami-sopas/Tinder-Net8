
using API.Extensions;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string KnownAs { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public string Gendeer { get; set; }

    public string Interests { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    //A user can have many photos (Navigation property)
    public List<Photo> Photos { get; set; } = new (); 
    

    //Metodo para calcular edad basado en su fecha de nacimiento
    public int GetAge()
    {
        return DateOfBirth.CalculateAge();
    }

}
