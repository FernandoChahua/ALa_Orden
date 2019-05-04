using Business;
using Business.Implementacion;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicioUsuario servicioUsuario = new ServicioUsuario();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(servicioUsuario.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (servicioUsuario.Insert(usuario))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            var cliente = servicioUsuario.FindById(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (servicioUsuario.Update(usuario))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            servicioUsuario.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Tarjetas(int id)
        {
            if (id != 0)
            {

                return RedirectToAction("Index", "Tarjeta", new { cl = id });
            }
            return View();

        }

        public ActionResult Pedidos(int id)
        {
            if (id != 0)
            {

                return RedirectToAction("Index", "Pedido", new { cl = id });
            }
            return View();
        }

    }
}
