using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Entity;

namespace Business.Implementacion
{
    public class ServicioCategoria : IServicioCategoria
    {
        private IRepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        public bool Insert(Categoria t)
        {

            return repositorioCategoria.Insert(t);
        }

        public List<Categoria> GetAll()
        {
            return repositorioCategoria.GetAll();
        }

        public Categoria FindById(int? id)
        {
            return repositorioCategoria.FindById(id);
        }

        public bool Update(Categoria t)
        {
            return repositorioCategoria.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioCategoria.Delete(id);
        }

    }
}
