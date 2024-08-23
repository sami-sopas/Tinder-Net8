
namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        //Al ser estatico, al llamar al metodo no le pasamos el parametro explicitamente, sino que se llama desde el objeto 
        public static int CalculateAge(this DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var age = today.Year - dateOfBirth.Year;

            if(dateOfBirth > today.AddYears(-age)) age--;

            return age;
        }
    }
}