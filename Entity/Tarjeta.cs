using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Tarjeta
    {
        public int IdTarjeta { get; set; }

        [Required(ErrorMessage = "Porfavor seleccione un cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese su numero de cuenta")]
        [DisplayName("Nro. de Cuenta")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "La longitud del numero de cuenta es de 16 digitos")]
        public string NroCuenta { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese el nombre del titular")]
        [DisplayName("Nombre del titular")]
        public string Titular { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese la fecha de expiracion de la tarjeta")]
        [DisplayName("Fecha de expiracion")]
        public string FechaExp { get; set; }
    }
}
