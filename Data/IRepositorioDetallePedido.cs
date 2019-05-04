using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public interface IRepositorioDetallePedido : IRepositorioCRUD<DetallePedido>
    {
        bool Delete(DetallePedido t);
        List<DetallePedido> GetByIdPedido(int idPedido);
        DetallePedido GetById(DetallePedido dp);
    }
}
