using BecasCep.Models;
using BecasCep.Models.Dominio;
using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.Persona;
using BecasCep.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecasCep.Controllers
{
    public class InscripcionController : Controller
    {
        private ApplicationDbContext db;
        // GET: Inscripcion
        public InscripcionController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Listado()
        {
            var repoPersona = new Repositorio<Persona>(db);
            var personas = repoPersona.TraerTodos().ToList().Select(p => new PersonaIndexViewModel()
            {
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                Email = p.Email,
                Telefono = p.Telefono,
                Carrera = new Models.ViewModels.Carrera.CarreraViewModel()
                {
                    Nombre = p.Carrera.Nombre,
                    Sede = p.Carrera.Sede,
                    Turno = p.Carrera.Turno
                }
            }).ToList();
            return View(personas);
        }

        public void CrearPersonasTest()
        {
            var repoPersona = new Repositorio<Persona>(db);
            Persona persona = null;
            for (int i = 0; i < 300; i++)
            {
                persona = new Persona()
                {
                    Nombre = "Nombre" + i,
                    Apellido = "Apellido" + i,
                    Dni = new Random().Next(0, 30333333).ToString(),
                    Email = "test" + i + "@test.com",
                    Telefono = new Random().Next(0, 30333333).ToString(),
                    Estado = false,
                    Sorteado = false,
                    Carrera = new Carrera()
                    {
                        Nombre = Enum.GetNames(typeof(TipoCarrera)).ToList().ElementAt(new Random().Next(0, 2)),
                        Sede = (Sede)Enum.Parse(typeof(Sede), Enum.GetNames(typeof(Sede)).ToList().ElementAt(new Random().Next(0, 2))),
                        Turno = (Turno)Enum.Parse(typeof(Turno), Enum.GetNames(typeof(Turno)).ToList().ElementAt(new Random().Next(0, 3))),
                    }
                };
                repoPersona.Crear(persona);
            }
        }

        public ActionResult Crear()
        {
            PersonaViewModel model = new PersonaViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(PersonaViewModel model)
        {
            Persona persona = new Persona(model);
            var repoPersona = new Repositorio<Persona>(db);
            repoPersona.Crear(persona);
            return RedirectToAction("Listado");
        }

      


    }
}