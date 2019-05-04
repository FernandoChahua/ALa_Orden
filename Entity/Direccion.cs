using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        public Usuario Usuario { get; set; }
        public string latencia { get; set; }
        public string latitud { get; set; }
        public string descripcion { get; set; }

    }
}
