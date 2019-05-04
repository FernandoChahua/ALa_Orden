using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;
namespace AlaOrden.Controllers
{
    public class DetallePedidoController : Controller
    {
        IServicioDetallePedido servicioDetallePedido = new ServicioDetallePedido();
        IServicioPedido servicioPedido = new ServicioPedido();
        IServicioProducto servicioProducto = new ServicioProducto();

        // GET: DetallePedido
        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                return View(servicioDetallePedido.GetAll());
            }
            else
            {
                List<DetallePedido> dp = servicioDetallePedido.GetByIdPedido(id);
                return View(dp);
            }
        }
        public ActionResult Delete(int p, int pr)
        {
            if (p != 0 && pr != 0)
            {
                DetallePedido dp = new DetallePedido();
                dp.IdPedido = p;
                dp.Producto.IdProducto = pr;
                servicioDetallePedido.Delete(dp);
                return RedirectToAction("Index", new { id = p });
            }

            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
            ViewBag.pedidos = servicioPedido.GetAll();
            ViewBag.productos = servicioProducto.GetAll();

            return View();
        }
        [HttpPost]
        public ActionResult Create(DetallePedido detallePedido)
        {
            if (servicioDetallePedido.Insert(detallePedido))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int p, int pr)
        {
            DetallePedido dp = new DetallePedido();
            Producto producto = new Producto();
            dp.IdPedido = p;
            producto.IdProducto = pr;
            dp.Producto = producto;
            ViewBag.productos = servicioProducto.GetAll();
            return View(servicioDetallePedido.FindById(dp));
        }
        [HttpPost]
        public ActionResult Edit(DetallePedido detallePedido)
        {
            if (servicioDetallePedido.Update(detallePedido))
            {
                return RedirectToAction("Index");

            }
            return View();

        }

    }
}