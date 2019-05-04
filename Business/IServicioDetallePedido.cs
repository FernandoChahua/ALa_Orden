using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public interface IServicioDetallePedido : IServicioCRUD<DetallePedido>
    {
        bool Delete(DetallePedido t);
        List<DetallePedido> GetByIdPedido(int idPedido);
        DetallePedido FindById(DetallePedido dp);
    }
}
