using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Cantidad { get; set; }
        public double Magnitud { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
