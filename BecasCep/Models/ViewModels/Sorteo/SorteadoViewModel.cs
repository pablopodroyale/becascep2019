using BecasCep.Models.ViewModels.Carrera;
using BecasCep.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.Sorteo
{
    public class SorteadoViewModel:EntidadViewModel
    {
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public  CarreraViewModel Carrera { get; set; }
        public bool Estado { get; set; }
        public bool Sorteado { get; set; }

    }
}