using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace Presentation.Util
{
    public class Carrito
    {
        public List<DetallePedido> DetallePedidos ;

        public Carrito()
        {
            DetallePedidos = new List<DetallePedido>();
        }


        public void AumentarCantidad(DetallePedido dp)
        {
            foreach (DetallePedido dep in DetallePedidos)
            {
                if (dep.Producto.IdProducto == dp.Producto.IdProducto)
                {
                    dep.Cantidad++;
                }
            }
        }
        public bool Existe(DetallePedido dp)
        {
            foreach(DetallePedido dep in DetallePedidos)
            {
                if(dep.Producto.IdProducto == dp.Producto.IdProducto)
                {
                    return true;
                }
            }
            return false;
        }
        public void DisminuirCantidad(DetallePedido dp)
        {
            foreach (DetallePedido dep in DetallePedidos)
            {
                if (dep.Producto.IdProducto == dp.Producto.IdProducto)
                {
                    dep.Cantidad++;
                }
            }
        }

        public void DeleteDetalle(DetallePedido dp)
        {
            DetallePedidos.Remove(dp);
        }

        public void AgregarDetalle(DetallePedido dp)
        {
                DetallePedidos.Add(dp);
        }
    }
}