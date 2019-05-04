using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entity;
using Business;
using Business.Implementacion;

namespace Alo.Controllers
{
    public class TarjetaController : Controller
    {
        // GET: Tarjeta
        private IServicioTarjeta servicioTarjeta = new ServicioTarjeta();
        private IServicioUsuario servicioUsuario = new ServicioUsuario();


        public ActionResult Index(int cl = 0)
        {
            if (cl != 0) {
                return View(servicioTarjeta.GetByUsuario(cl));
            }
            else
            {
                return View(servicioTarjeta.GetAll());
            }

        }

        public ActionResult Create()
        {
            //ViewBag.cliente = cliente;
            ViewBag.usuarios = servicioUsuario.GetAll();
            return View();
        }

        [HttpPost]

        public ActionResult Create(Usuario usuario, Tarjeta Tarjeta)
        {
            ViewBag.usuarios = servicioUsuario.GetAll();
            bool rptaInsert = servicioTarjeta.Insert(Tarjeta);

            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.tarjeta = servicioTarjeta.GetAll();
            bool rptaInsert = servicioTarjeta.Delete(id);

            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewBag.usuarios = servicioUsuario.GetAll();

            Tarjeta tarjeta = servicioTarjeta.FindById(id);
            ViewBag.tarjeta = servicioTarjeta.GetAll();
            return View(tarjeta);
        }

        [HttpPost]

        public ActionResult Edit(Tarjeta Tarjeta)
        {
            ViewBag.usuarios = servicioUsuario.GetAll();
            ViewBag.tarjeta = servicioTarjeta.GetAll();

            bool rptaEdit = servicioTarjeta.Update(Tarjeta);

            if (rptaEdit)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}