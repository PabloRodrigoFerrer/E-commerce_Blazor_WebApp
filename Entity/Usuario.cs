using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum TipoUsuario 
    {
        NORMAL = 1,
        ADMIN = 2
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? sexo { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El email debe tener un dominio válido")]
        public string? Email { get; set; }

        public string? Usuario { get; set; }

        [Required(ErrorMessage = "Ingresar una contraseña es obligatorio")]
        public string Pass { get; set; }

        public string? urlImagen { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public string? Direccion { get; set; }

        public bool isAdmin
        {
            get { return TipoUsuario == TipoUsuario.ADMIN; }
        }



        //public Usuario(string dato, string Pass)
        //{

        //    if (esEmail(dato))
        //    {
        //        this.Email = dato;
        //    }
        //    else
        //    {
        //        this.User = dato;
        //    }
        //    this.Pass = Pass;
        //}
    }
}
