using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Enums
{
    [Flags]
    public enum Turno
    {
        Mañana = 1,
        Tarde = 2,
        Noche = 3
    }

    public static class TurnoConst
    {
        public const string Mañana = "Mañana";
        public const string Tarde = "Tarde";
        public const string Noche = "Noche";

    }
}