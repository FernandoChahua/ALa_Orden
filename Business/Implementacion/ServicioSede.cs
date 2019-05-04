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
    public class ServicioSede : IServicioSede
    {
        IRepositorioSede repositorioSede = new RepositorioSede();

        public bool Delete(int id)
        {
            return repositorioSede.Delete(id);
        }

        public List<Sede> GetAll()
        {
            return repositorioSede.GetAll();
        }

        public Sede GetById(int? id)
        {
            return repositorioSede.GetById(id);
        }

        public bool Insert(Sede s)
        {
            return repositorioSede.Insert(s);
        }

        public bool Update(Sede s)
        {
            return repositorioSede.Update(s);
        }
    }
}
