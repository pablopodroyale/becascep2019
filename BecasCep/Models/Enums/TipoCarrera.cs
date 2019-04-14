using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Enums
{
    [Flags]
    public enum TipoCarrera
    {
        LicEnPsicologia = 1,
        LicEnTerapiaOcupacional = 2
    }

    public static class TipoCarreraConst
    {
        public const string LicEnPsicologia = "Lic. en Psicología";
        public const string LicEnTerapiaOcupacional = "Lic. en Terapia Ocupacional";

    }
}