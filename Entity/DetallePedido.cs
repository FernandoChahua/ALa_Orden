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


        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
