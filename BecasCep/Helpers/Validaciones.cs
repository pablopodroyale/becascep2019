using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BecasCep.Helpers
{
    public static class Validaciones
    {
        public static bool DniValido(string dni)
        {
            Regex regex = new Regex(@"/^\d{8}(?:[-\s]\d{4})?$/");
            Match match = regex.Match(dni);
            return match.Success;
        }
    }
}