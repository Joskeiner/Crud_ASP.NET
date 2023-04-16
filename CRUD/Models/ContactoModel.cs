
using System.ComponentModel.DataAnnotations;


namespace CRUD.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string?  Nombre { get; set; }
        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
