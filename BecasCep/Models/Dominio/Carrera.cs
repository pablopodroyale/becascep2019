using BecasCep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Dominio
{
    public class Carrera:Entidad
    {
        public Sede Sede { get; set; }
        public Turno Turno { get; set; }
    }
}