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
    public class PedidoController : Controller
    {
        IServicioPedido servicioPedido = new ServicioPedido();
        IServicioUsuario servicioCliente = new ServicioUsuario();
        IServicioSede servicioSede = new ServicioSede();
        // GET: Pedido
        public ActionResult Index(int cl = 0)
        {
            if (cl == 0)
                return View(servicioPedido.GetAll());
            else
                return View(servicioPedido.GetByUsuario(cl));
        }

        public ActionResult Delete(int? p)
        {
            if (p == null)
            {
                servicioPedido.Delete(p.Value);
            }

            return RedirectToAction("Index");

        }
        public ActionResult Details(int dp)
        {
            if (dp != 0)
            {

                return RedirectToAction("Index", "DetallePedido", new { id = dp });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.clientes = servicioCliente.GetAll();
            ViewBag.sedes = servicioSede.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pedido p)
        {
            if (p != null)
            {
                servicioPedido.Insert(p);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int p)
        {
            ViewBag.clientes = servicioCliente.GetAll();
            ViewBag.sedes = servicioSede.GetAll();
            return View(servicioPedido.FindById(p));
        }
        [HttpPost]
        public ActionResult Edit(Pedido pedido)
        {
            if (servicioPedido.Update(pedido))
            {
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}