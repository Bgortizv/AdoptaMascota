using AdoptarMascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoptarMascota.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Registra una mascota para dar en adopción.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Mascota mascota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Mascota sdb = new DAL.Mascota();
                    if (sdb.AgregarMascota(mascota))
                    {
                        ViewBag.Message = "Gracias por registrar a " + mascota.Nombre;
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al registrar mascota";
                return View();
            }
        }

        public ActionResult Adoptar()
        {
            ViewBag.Message = "Encuentra tu mascota ideal!";
            DAL.Mascota mascota = new DAL.Mascota();
            List<Mascota> mascotas = mascota.ListarMascotas();

            return View(mascotas);
        }
    }
}