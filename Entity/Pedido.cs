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

       
        public Sede Sede { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el estado")]
        [DisplayName("Estado")]
        public string Estado { get; set; }


        public DateTime Fecha { get; set; }


        public string Direccion;

        public int nroTransaccion;

        //public Descuento SubTotal{get;set;} falta quitarle  {}

    public double PrecioEnvio { get; set; }

    public double Descuento { get; set; }

    public List<DetallePedido> DetallesPedidos { get; set; }
    }
}
