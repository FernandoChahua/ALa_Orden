using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Marca
    {
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre de la Marca")]
        [DisplayName("Marca")]
        public string Nombre { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
