using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.Sorteo
{
    public class SorteoViewModel:EntidadViewModel
    {
        public Sede Sede { get; set; }
        public Turno Turno { get; set; }
    }
}