using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using Data;
using Data.Implementacion;
namespace Business.Implementacion
{
    public class ServicioDetallePedido : IServicioDetallePedido
    {
        IRepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido();
        public bool Insert(DetallePedido t)
        {
            return repositorioDetallePedido.Insert(t);
        }

        public bool Update(DetallePedido t)
        {
            return repositorioDetallePedido.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioDetallePedido.Delete(id);
        }

        public List<DetallePedido> GetAll()
        {
            return repositorioDetallePedido.GetAll();
        }

        public DetallePedido GetById(int? id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(DetallePedido t)
        {
            return repositorioDetallePedido.Delete(t);
        }
        public List<DetallePedido> GetByIdPedido(int idPedido)
        {
            return repositorioDetallePedido.GetByIdPedido(idPedido);
        }
        public DetallePedido FindById(DetallePedido dp)
        {
            return repositorioDetallePedido.FindById(dp);
        }
        public DetallePedido FindById(int? id)
        {
            return null;
        }
    }
}
