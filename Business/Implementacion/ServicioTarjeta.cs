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
    public class ServicioTarjeta: IServicioTarjeta
    {
        private IRepositorioTarjeta repositorioTarjeta = new RepositorioTarjeta();

        public bool Insert(Tarjeta t){

            return repositorioTarjeta.Insert(t);
        }

        public List<Tarjeta> GetAll()
        {
            return repositorioTarjeta.GetAll();
        }

        public Tarjeta FindById(int? id)
        {
            return repositorioTarjeta.FindById(id);
        }

        public bool Update(Tarjeta t)
        {
            return repositorioTarjeta.Update(t);
        }

        public bool Delete(int id)
        {
            return repositorioTarjeta.Delete(id);
        }

        public List<Tarjeta> GetByUsuario(int idUsuario)
        {
            return repositorioTarjeta.GetByUsuario(idUsuario);
        }
    }
}
