using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Enums
{
    [Flags]
    public enum Sede
    {
        SanIsidro = 1,
        CABA = 2
    }

    public static class SedeConst
    {
        public const string SanIsidro = "San Isidro";
        public const string CABA = "CABA";
      
    }
}