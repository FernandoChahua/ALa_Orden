using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una longitud válida")]
        public double Longitud { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una latitud válida")]
        public double Latitud { get; set; }
        public string Descripcion { get; set; }

    }
}
