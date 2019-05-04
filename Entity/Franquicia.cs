using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Franquicia
    {
        public int IdFranquicia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre de la Franquicia")]
        [DisplayName("Nombre Franquicia")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la direccion URL")]
        [DisplayName("Direccion URL")]
        public string Url { get; set; }

        public string Logo { get; set; }
        public List<Sede> Sedes { get; set; }
        public List<ProductoFranquicia> ProductoFranquicias { get; set; }

    }
}
