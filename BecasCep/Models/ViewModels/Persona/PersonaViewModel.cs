using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.Carrera;
using BecasCep.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BecasCep.Models.ViewModels.Persona
{
    public class PersonaViewModel:EntidadViewModel
    {
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
     
        public List<TipoCarrera> Carreras { get; set; }
        public List<Turno> Turnos { get; set; }
        public List<Sede> Sedes { get; set; }
        public CarreraViewModel Carrera { get; set; }
        public bool Estado { get; set; }

        public PersonaViewModel()
        {
            Carrera = new CarreraViewModel();
            Carreras = new List<TipoCarrera>();
            Sedes = new List<Sede>();
            Turnos = new List<Turno>();
            LlenarListas();
        }

        private void LlenarListas()
        {
            foreach (var item in Enum.GetNames(typeof(TipoCarrera)))
            {
                Carreras.Add((TipoCarrera)Enum.Parse(typeof(TipoCarrera), item));
            }
            foreach (var item in Enum.GetNames(typeof(Sede)))
            {
                Sedes.Add((Sede)Enum.Parse(typeof(Sede), item));
            }
            foreach (var item in Enum.GetNames(typeof(Turno)))
            {
                Turnos.Add((Turno)Enum.Parse(typeof(Turno), item));
            }
        }
    }

    

}