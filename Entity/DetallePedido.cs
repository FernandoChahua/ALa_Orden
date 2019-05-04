using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class DetallePedido {
        public int IdPedido { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el precio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una cantidad válida")]
        public int Cantidad { get; set; }

    }
}
