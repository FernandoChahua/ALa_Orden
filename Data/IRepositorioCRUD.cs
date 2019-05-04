using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepositorioCRUD<T>
    {
        bool Insert(T t);
        bool Update(T t);
        bool Delete(int id);
        T FindById(int? id);
        List<T> GetAll();
    }
}

