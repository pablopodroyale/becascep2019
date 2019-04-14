using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BecasCep.Models.ViewModels.Carrera;
using BecasCep.Models.ViewModels.Persona;

namespace BecasCep.Models.Dominio
{
    public class Persona:Entidad
    {

        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public virtual Carrera Carrera { get; set; }
        public bool Estado { get; set; }
        public bool Sorteado { get; set; }
        public Persona()
        {
            
        }

        public Persona(PersonaViewModel model)
        {
            Nombre = model.Nombre;
            Apellido = model.Apellido;
            Dni = model.Dni;
            Email = model.Email;
            Telefono = model.Telefono;
            Carrera = new Carrera();
            setCarrera(model.Carrera);
            Estado = model.Estado;
        }

        private void setCarrera(CarreraViewModel model)
        {
            Carrera.Nombre = model.Nombre = model.Nombre;
            Carrera.Sede = model.Sede;
            Carrera.Turno = model.Turno;
                 
        }
    }
}