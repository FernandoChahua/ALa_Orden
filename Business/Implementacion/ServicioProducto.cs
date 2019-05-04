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
    public class ServicioProducto : IServicioProducto
    {
        private IRepositorioProducto repositorioProducto = new RepositorioProducto();

        public bool Delete(int id)
        {
            return repositorioProducto.Delete(id);
        }

        public List<Producto> GetAll()
        {
            return repositorioProducto.GetAll();
        }

        public Producto FindById(int? id)
        {
            return repositorioProducto.FindById(id);
        }

        public bool Insert(Producto t)
        {
            return repositorioProducto.Insert(t);
        }

        public bool Update(Producto t)
        {
            return repositorioProducto.Update(t);
        }
    }
}
