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
        private IServicioCategoria servicioCategoria = new ServicioCategoria();
        private IServicioMarca servicioMarca = new ServicioMarca();
        // GET: Producto
        public ActionResult Index()
        {
            return View(servicioProducto.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.categorias = servicioCategoria.GetAll();
            ViewBag.marcas = servicioMarca.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            ViewBag.categorias = servicioCategoria.GetAll();
            ViewBag.marcas = servicioMarca.GetAll();
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
            ViewBag.categorias = servicioCategoria.GetAll();
            ViewBag.marcas = servicioMarca.GetAll();
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
            ViewBag.categorias = servicioCategoria.GetAll();
            ViewBag.marcas = servicioMarca.GetAll();
            bool rptaEdit = servicioProducto.Update(p);
            if (rptaEdit)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}