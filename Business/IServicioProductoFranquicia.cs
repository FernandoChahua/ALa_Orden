using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public interface IServicioProductoFranquicia : IServicioCRUD<ProductoFranquicia>
    {
        bool Delete(int idProducto, int idFranquicia);

        ProductoFranquicia FindById(ProductoFranquicia pf);
    }
}
