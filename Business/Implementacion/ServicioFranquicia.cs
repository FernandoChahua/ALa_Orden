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
    public class ServicioFranquicia : IServicioFranquicia
    {
        private IRepositorioFranquicia repositorioFranquicia = new RepositorioFranquicia();

        public bool Insert(Franquicia f)
        {
            return repositorioFranquicia.Insert(f);
        }

        public bool Update(Franquicia f)
        {
            return repositorioFranquicia.Update(f);
        }

        public bool Delete(int id)
        {
            return repositorioFranquicia.Delete(id);
        }

        public Franquicia GetById(int? id)
        {
            return repositorioFranquicia.GetById(id);
        }

        public List<Franquicia> GetAll()
        {
            return repositorioFranquicia.GetAll();
        }
    }
}
