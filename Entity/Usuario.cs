using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese email valido")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Por favor ingrese un email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de usuario")]
        [DisplayName("Nombre de Usuario")]
        public string Apodo { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public List<Direccion> Direcciones { get; set; }

        
    }
}
