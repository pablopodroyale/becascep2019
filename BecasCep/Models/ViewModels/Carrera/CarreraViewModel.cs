using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.Carrera
{
    public class CarreraViewModel:EntidadViewModel
    {
        [Required]
        public Sede Sede { get; set; }
        [Required]
        public Turno Turno { get; set; }
    }
}