using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;
using Entity;

namespace Presentation.Controllers
{
    public class MarcaController : Controller
    {
        IServicioMarca servicioMarca = new ServicioMarca();

        // GET: Marca
        public ActionResult Index()
        {
            return View(servicioMarca.GetAll());
        }

        public ActionResult Create()
        {
            Marca marca = new Marca();
            return View(marca);
        }

        [HttpPost]
        public ActionResult Create(Marca marca)
        {
            if (servicioMarca.Insert(marca))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            return View(servicioMarca.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            if (servicioMarca.Update(marca))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (servicioMarca.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}