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
        public string Estado { get; set; }


        public string Fecha { get; set; }


        public string Direccion { get; set; }

        public int NroTransaccion { get; set; }

        //public Descuento SubTotal{get;set;} falta quitarle  {}

        public double SubTotal { get; set; }
        public double PrecioEnvio { get; set; }

        public double Descuento { get; set; }

        public List<DetallePedido> DetallesPedidos { get; set; }
    }
}
