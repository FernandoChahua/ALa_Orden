﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public interface IRepositorioProducto : IRepositorioCRUD<Producto>
    {
        List<Producto> GetByCategoria(int idCategoria);
        List<Producto> GetByMarca(int idMarca);
    }
}
