using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
    public interface IRepositorioDireccion : IRepositorioCRUD<Direccion>
    {
        List<Direccion> FindByUsuario(int idUsuario);
        bool DeleteByUsuario(int idUsuario);
    }
}
