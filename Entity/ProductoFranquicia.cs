using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoFranquicia
    {
        public Producto Producto { get; set; }

        public Franquicia Franquicia { get; set; }

        //provisional??
        public string CodRef { get; set; }
    }
}
