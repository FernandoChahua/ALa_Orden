using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        // public Usuario usuario;  iria usuario?

        public Usuario Usuario { get; set; }
        public Sede Sede { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el estado")]
        [DisplayName("Estado")]
        public string estado { get; set; }


        public DateTime fecha { get; set; }


        public string direccion;

        public int nroTransaccion;

        //public Descuento SubTotal{get;set;} falta quitarle  {}

        public double subtotal { get; set; }
        public double precioEnvio { get; set; }

    public double descuento { get; set; }

    public List<DetallePedido> DetallesPedidos { get; set; }
    }
}
