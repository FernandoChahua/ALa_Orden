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
    public class FranquiciaController : Controller
    {
        IServicioFranquicia servicioFranquicia = new ServicioFranquicia();

        // GET: Franquicia
        public ActionResult Index()
        {
            return View(servicioFranquicia.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Franquicia f)
        {
            if (servicioFranquicia.Insert(f))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            return View(servicioFranquicia.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(Franquicia f)
        {
            if (servicioFranquicia.Update(f))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            Franquicia f = servicioFranquicia.FindById(id);

            if (f.Sedes.Count>0||servicioFranquicia.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}