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

        public ActionResult Edit(int? idP, int? idF)
        {
            ProductoFranquicia pf = new ProductoFranquicia
            {
                Producto = new Producto { IdProducto = idP.Value },
                Franquicia = new Franquicia { IdFranquicia = idF.Value }
            };
            ViewBag.franquicias = servicioFranquicia.GetAll();
            ViewBag.productos = servicioProducto.GetAll();
            pf = servicioProductoFranquicia.FindById(pf);

            return View(pf);
        }

        [HttpPost]
        public ActionResult Edit(ProductoFranquicia productoFranquicia)
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            ViewBag.productos = servicioProducto.GetAll();
            if (servicioProductoFranquicia.Insert(productoFranquicia))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? idP, int? idF)
        {
            servicioProductoFranquicia.Delete(idP.Value, idF.Value);
            return View();
        }
    }

    
}