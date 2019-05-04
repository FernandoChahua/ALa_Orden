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
    public class CategoriaController : Controller
    {
        IServicioCategoria servicioCategoria = new ServicioCategoria();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(servicioCategoria.GetAll());
        }

        public ActionResult Create()
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (servicioCategoria.Insert(categoria))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id) {
            return View(servicioCategoria.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (servicioCategoria.Update(categoria))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (servicioCategoria.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}