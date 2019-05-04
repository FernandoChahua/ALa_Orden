using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;

namespace Presentation.Controllers
{
    public class ProductoFranquiciaController : Controller
    {

        IServicioProductoFranquicia servicioProductoFranquicia = new ServicioProductoFranquicia();

        IServicioProducto servicioProducto = new ServicioProducto();

        IServicioFranquicia servicioFranquicia = new ServicioFranquicia();
        // GET: ProductoFranquicia
        public ActionResult Index()
        {
            return View(servicioProductoFranquicia.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            ViewBag.productos = servicioProducto.GetAll();

            ProductoFranquicia productoFranquicia = new ProductoFranquicia { Producto = new Producto(), Franquicia = new Franquicia()};
            return View(productoFranquicia);
        }

        [HttpPost]
        public ActionResult Create(ProductoFranquicia productoFranquicia)
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            ViewBag.productos = servicioProducto.GetAll();
            if (servicioProductoFranquicia.Insert(productoFranquicia))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int? idP, int? idF)
        {
            servicioProductoFranquicia.Delete(idP.Value, idF.Value);
            return View();
        }
    }

    
}