using BecasCep.Models;
using BecasCep.Models.Dominio;
using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.Sorteo;
using BecasCep.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecasCep.Controllers
{
    [Authorize(Roles = RoleConst.Administrador)]
    public class SorteoController : Controller
    {
        private ApplicationDbContext db;
        // GET: Sorteo
       
        public SorteoController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Sorteo()
        {
            SorteoViewModel model = new SorteoViewModel();
            return View(model);
        }

        public ActionResult Sorteado(SorteoViewModel model)
        {
            var repoInscriptos = new Repositorio<Persona>(db);
            var personas = repoInscriptos.TraerTodos().Where(p => !p.Eliminado && !p.Sorteado && p.Estado == false && p.Carrera.Sede == model.Sede && p.Carrera.Turno == model.Turno);
            int tope = personas.Count() - 1;
            var personaSorteada = personas.ElementAtOrDefault(new Random().Next(0,tope));
            SorteadoViewModel sorteado = null;
            if (personaSorteada != null)
            {
                sorteado = new SorteadoViewModel()
                {
                    Id = personaSorteada.Id,
                    Nombre = personaSorteada.Nombre,
                    Apellido = personaSorteada.Apellido,
                    Dni = personaSorteada.Dni,
                    Email = personaSorteada.Email,
                    Telefono = personaSorteada.Telefono,
                };
            }
            
            return View(sorteado);
        }

        public ActionResult Confirmar(Guid id)
        {
            var repoPersona = new Repositorio<Persona>(db);
            var persona = repoPersona.Traer(id);
            persona.Sorteado = true;
            repoPersona.Modificar(persona);
            return RedirectToAction("Sorteo");
        }

    }
}