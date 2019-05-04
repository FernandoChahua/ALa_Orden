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
        [Required(ErrorMessage = "Por favor ingrese un nombre válido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una presentación válida")]
        public string Presentacion { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una cantidad válida")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una magnitud válida")]
        public double Magnitud { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una unidad válida")]
        public string Unidad { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una descripción válida")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
