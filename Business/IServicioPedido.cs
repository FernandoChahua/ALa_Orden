using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public interface IServicioPedido : IServicioCRUD<Pedido>
    {
        List<Pedido> GetByUsuario(int idUsuario);
    }
}
