using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }


        //Foreign Key Full defined relationship (Asegura que no exista una foto sin tener un usuario asociado)
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}