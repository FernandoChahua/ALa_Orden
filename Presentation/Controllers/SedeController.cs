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
    public class SedeController : Controller
    {
        IServicioSede servicioSede = new ServicioSede();
        IServicioFranquicia servicioFranquicia = new ServicioFranquicia();

        // GET: Sede
        public ActionResult Index()
        {
            return View(servicioSede.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sede sede)
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            if (servicioSede.Insert(sede))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            return View(servicioSede.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(Sede sede)
        {
            ViewBag.franquicias = servicioFranquicia.GetAll();
            if (servicioSede.Update(sede))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (servicioSede.Delete(id.Value))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}