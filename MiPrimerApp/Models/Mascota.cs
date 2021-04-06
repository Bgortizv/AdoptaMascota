using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimerApp.Models
{
    public class Mascota
    {
        public string nombre { get; set; }
        public string Edad { get; set; }
        public string Descrip { get; set; }
        public string EmailContacto { get; set; }
        public bool Adoptada { get; set; } 
    }
}