﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
    public interface IRepositorioTarjeta:IRepositorioCRUD<Tarjeta>
    {
        List<Tarjeta> GetByUsuario(int idUsuario);
    }
}
