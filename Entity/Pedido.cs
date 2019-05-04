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

        [Required(ErrorMessage = "Por favor ingrese una fecha válido")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una direccion válida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un número de transacción válida")]
        public int NroTransaccion { get; set; }

        //public Descuento SubTotal{get;set;} falta quitarle  {}

        [Required(ErrorMessage = "Por favor ingrese un sub total válido")]
        public double SubTotal { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un precio de envío válido")]
        public double PrecioEnvio { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un monto de descuento válido")]
        public double Descuento { get; set; }

        public List<DetallePedido> DetallesPedidos { get; set; }
    }
}
