using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptarMascota.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Descrip { get; set; }
        public string CorreoContacto { get; set; }
        public bool Adoptado { get; set; }
    }
}