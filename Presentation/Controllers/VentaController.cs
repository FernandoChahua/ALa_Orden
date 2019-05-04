using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;
using Presentation.Util;
namespace Presentation.Controllers
{
    public class VentaController : Controller
    {
        Carrito carrito = new Carrito();
        IServicioProducto servicioProducto = new ServicioProducto();
        Usuario usuario = new Usuario();
        IServicioUsuario servicioUsuario = new ServicioUsuario();

        // GET: Venta
        public ActionResult Index()
        {
            return View(servicioProducto.GetAll());
        }

        public ActionResult Agregar(int id)
        {
            DetallePedido dp = new DetallePedido();
            dp.Producto = servicioProducto.FindById(id);
            dp.Cantidad = 0;
            carrito.AgregarDetalle(dp);

            return RedirectToAction("Index");
        }

        public ActionResult Carrito()
        {
            return View(carrito.DetallePedidos);
        }

        public ActionResult VariarCantidad(int id ,int flag)
        {
            DetallePedido dp = new DetallePedido
            {
                Producto = new Producto
                {
                    IdProducto = id
                }
            };

            if (flag == 0)
            {
                carrito.AumentarCantidad(dp);
            }
            else
            {
                carrito.DisminuirCantidad(dp);
            }

            return RedirectToAction("Carrito");
        }
        public ActionResult EliminarCarrito(int id)
        {
            DetallePedido dp = new DetallePedido
            {
                Producto = new Producto
                {
                    IdProducto = id
                }
            };
            carrito.DeleteDetalle(dp);
            return RedirectToAction("Carrito");
        }
    }
}