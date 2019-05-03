using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el nombre de la Categoria")]
        [DisplayName("Nombre Categoria")]
        private string Nombre { get; set; }

        private List<Producto> Productos { get; set; }
    }
}
