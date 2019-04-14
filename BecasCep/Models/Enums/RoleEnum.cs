using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Enums
{
    [Flags]
    public enum RoleEnum
    {
        Administrador,
        Suscriptor,
        Test
    }

    public static class RoleConst
    {
        public const string Administrador = "Administrador";
        public const string Suscriptor = "Suscriptor";
        public const string Test = "Test";
    }
}