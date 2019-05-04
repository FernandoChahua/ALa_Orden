using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;
using Business.Implementacion;


namespace ALaOrden.Controllers
{
    public class ProductoController : Controller
    {
        private IServicioProducto servicioProducto = new ServicioProducto();
        // GET: Producto
        public ActionResult Index()
        {
            return View(servicioProducto.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.producto = servicioProducto.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            ViewBag.producto = servicioProducto.GetAll();
            bool rptaInsert = servicioProducto.Insert(producto);
            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (servicioProducto.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Producto producto = servicioProducto.FindById(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rptaEdit = servicioProducto.Update(p);
            if (rptaEdit)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}