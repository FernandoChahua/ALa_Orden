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
        public int IdUsuario { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Descripcion { get; set; }

    }
}
