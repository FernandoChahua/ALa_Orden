using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
    public interface IRepositorioProductoFranquicia : IRepositorioCRUD<ProductoFranquicia>
    {
        bool Delete(int idProducto, int idFranquicia);
        List<ProductoFranquicia> GetByFranquicia(int idFranquicia);
    }
}
