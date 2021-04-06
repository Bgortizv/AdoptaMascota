using MiPrimerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerApp.Controllers
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
            ViewBag.Message = "Registra una mascota para darla en adopción.";

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
                        ViewBag.Message = "Gracias por registrar a: " + mascota.nombre;
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Error al registrar mascota";
                return View();
            }          
        }

        public ActionResult Adoptar()
        {
            ViewBag.Message = "Encuentra tu nueva mascota";
            DAL.Mascota cdMascota = new DAL.Mascota();
            List<Models.Mascota> mascotas = cdMascota.ObtenerMascotas();

            return View(mascotas);
        }
    }
}