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
    public class ServicioProductoFranquicia : IServicioProductoFranquicia
    {
        private IRepositorioProductoFranquicia repositorioProductoFranquicia = new RepositorioProductoFranquicia();

        public bool Insert(ProductoFranquicia t)
        {

            return repositorioProductoFranquicia.Insert(t);
        }

        public List<ProductoFranquicia> GetAll()
        {
            return repositorioProductoFranquicia.GetAll();
        }

        public ProductoFranquicia FindById(int? id)
        {
            return repositorioProductoFranquicia.FindById(id);
        }

        public bool Update(ProductoFranquicia t)
        {
            return repositorioProductoFranquicia.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioProductoFranquicia.Delete(id);
        }

        public List<ProductoFranquicia> FindByFranquicia(int idFranquicia)
        {
            return repositorioProductoFranquicia.GetByFranquicia(idFranquicia);
        }
        public bool Delete(int idProducto, int idFranquicia)
        {
            return repositorioProductoFranquicia.Delete(idProducto, idFranquicia);
        }

    }
}
