using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.General
{
    public class EntidadViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Debe Completar el Nombre")]
        public string Nombre { get; set; }
    }
}