using BecasCep.Models.ViewModels.Carrera;
using BecasCep.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.Persona
{
    public class PersonaIndexViewModel:EntidadViewModel
    {
     
        public string Apellido { get; set; }
      
        public string Dni { get; set; }
      
        public string Email { get; set; }
       
        public string Telefono { get; set; }

        public CarreraViewModel Carrera { get; set; }
        public bool Estado { get; set; }

        public PersonaIndexViewModel()
        {
            Carrera = new CarreraViewModel();
        }
    }
}