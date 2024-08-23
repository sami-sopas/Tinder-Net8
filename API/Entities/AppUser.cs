
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

    public string Gender { get; set; }

    public string Interests { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    //A user can have many photos (Navigation property)
    public List<Photo> Photos { get; set; } = new (); 
    

    //Metodo para calcular edad basado en su fecha de nacimiento
    //AutoMapper lee este metodo y lo usuara para mapear la edad del usuario
    //De esa manera evitamos hacer ese calculo nosotros durante el mapeo

    /*NOTA: USAR ESTE TIPO DE METODOS HARA QUE AUTOMAPPER TENGA QUE ACCEDER A TODAS LAS PROPIEDADES
            Y ESO HARA QUE HAGA UN SELECT DE TODAS LAS COLUMNAS AUNQUE USEMOS PROJECTION o SELECT ESPECIFICO
    */
    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }

    //Esto funciona???
    // public string GetPhotoUrl()
    // {
    //     var mainPhoto = Photos.FirstOrDefault(x => x.IsMain);

    //     return mainPhoto?.Url;
    // }

}
