using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entity
{
    public class ProductoFranquicia
    {
        public Producto Producto { get; set; }

        public Franquicia Franquicia { get; set; }

        //provisional??
        [Required(ErrorMessage = "Por favor ingrese una magnitud válida")]
        [DisplayName("Código de referencia")]
        public string CodRef { get; set; }
    }
}
