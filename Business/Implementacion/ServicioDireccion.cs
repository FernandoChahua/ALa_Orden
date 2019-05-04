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
    public class ServicioDireccion : IServicioDireccion
    {
        private IRepositorioDireccion repositorioDireccion = new RepositorioDireccion();

        public bool Insert(Direccion t)
        {

            return repositorioDireccion.Insert(t);
        }

        public List<Direccion> GetAll()
        {
            return repositorioDireccion.GetAll();
        }

        public Direccion FindById(int? id)
        {
            return repositorioDireccion.FindById(id);
        }

        public bool Update(Direccion t)
        {
            return repositorioDireccion.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioDireccion.Delete(id);
        }

        public List<Direccion> FindByUsuario(int idUsuario)
        {
            return repositorioDireccion.FindByUsuario(idUsuario);
        }
        public bool DeleteByUsuario(int idUsuario)
        {
            return repositorioDireccion.DeleteByUsuario(idUsuario);
        }
    }
}
