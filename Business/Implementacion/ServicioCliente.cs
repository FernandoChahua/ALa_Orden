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
    public class ServicioCliente : IServicioCliente
    {
        private IRepositorioCliente repositorioCliente = new RepositorioCliente();

        public bool Delete(int id)
        {
            return repositorioCliente.Delete(id);
        }

        public bool Insert(Cliente c)
        {
            return repositorioCliente.Insert(c);
        }

        public List<Cliente> GetAll()
        {
            return repositorioCliente.GetAll();
        }

        public Cliente GetById(int? id)
        {
            return repositorioCliente.GetById(id);
        }

        public bool Update(Cliente c)
        {
            return repositorioCliente.Update(c);
        }
    }
}
