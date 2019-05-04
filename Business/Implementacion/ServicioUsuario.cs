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
    public class ServicioUsuario : IServicioUsuario
    {
        private IRepositorioUsuario repositorioUsuario = new RepositorioUsuario();

        public bool Delete(int id)
        {
            return repositorioUsuario.Delete(id);
        }

        public bool Insert(Usuario c)
        {
            return repositorioUsuario.Insert(c);
        }

        public List<Usuario> GetAll()
        {
            return repositorioUsuario.GetAll();
        }

        public Usuario FindById(int? id)
        {
            return repositorioUsuario.FindById(id);
        }

        public bool Update(Usuario c)
        {
            return repositorioUsuario.Update(c);
        }
    }
}
