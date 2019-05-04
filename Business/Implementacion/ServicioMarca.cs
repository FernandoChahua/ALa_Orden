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
    public class ServicioMarca : IServicioMarca
    {
        private IRepositorioMarca repositorioMarca = new RepositorioMarca();

        public bool Insert(Marca t)
        {

            return repositorioMarca.Insert(t);
        }

        public List<Marca> GetAll()
        {
            return repositorioMarca.GetAll();
        }

        public Marca FindById(int? id)
        {
            return repositorioMarca.FindById(id);
        }

        public bool Update(Marca t)
        {
            return repositorioMarca.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioMarca.Delete(id);
        }

       
    }
}
