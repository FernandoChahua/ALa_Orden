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
    public class ServicioCliente : IServicioUsuario
    {
        private IRepositorioUsuario repositorioCliente = new RepositorioUsuario();

        public bool Delete(int id)
        {
            return repositorioCliente.Delete(id);
        }

        public bool Insert(Usuario c)
        {
            return repositorioCliente.Insert(c);
        }

        public List<Usuario> GetAll()
        {
            return repositorioCliente.GetAll();
        }

        public Usuario GetById(int? id)
        {
            return repositorioCliente.GetById(id);
        }

        public bool Update(Usuario c)
        {
            return repositorioCliente.Update(c);
        }
    }
}
