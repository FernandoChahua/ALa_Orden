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
    public class ServicioPedido : IServicioPedido
    {
        IRepositorioPedido repositorioPedido = new RepositorioPedido();

        public bool Delete(int id)
        {
            return repositorioPedido.Delete(id);
        }

        public List<Pedido> GetAll()
        {
            return repositorioPedido.GetAll();
        }

        public Pedido GetById(int? id)
        {
            return repositorioPedido.GetById(id);
        }

        public bool Insert(Pedido p)
        {
            return repositorioPedido.Insert(p);
        }

        public bool Update(Pedido p)
        {
            return repositorioPedido.Update(p);
        }

        public List<Pedido> GetByCliente(int idCliente)
        {
            return repositorioPedido.GetByCliente(idCliente);
        }
    }
}
