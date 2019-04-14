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
    //[Authorize (Roles = RoleConst.Administrador)]
    public class AdminController : Controller
    {
        private ApplicationDbContext db;

        public AdminController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult ListadoAdmin()
        {
            var repoPersona = new Repositorio<Persona>(db);
            var personas = repoPersona.TraerTodos().Where(p => !p.Eliminado).OrderBy(p => p.Nombre).ToList().Select(p => new PersonaIndexViewModel()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                Email = p.Email,
                Telefono = p.Telefono,
                Estado = p.Estado,
                Carrera = new Models.ViewModels.Carrera.CarreraViewModel()
                {
                    Nombre = p.Carrera.Nombre,
                    Sede = p.Carrera.Sede,
                    Turno = p.Carrera.Turno
                    
                }
            }).ToList();
            return View(personas);
        }

        public JsonResult Eliminar(Guid id)
        {
            var repoPersona = new Repositorio<Persona>(db);
            repoPersona.Eliminar(repoPersona.Traer(id));
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult CambiarEstado(bool estado, Guid id)
        {
            var repoPersona = new Repositorio<Persona>(db);
            var persona = repoPersona.Traer(id);
            persona.Estado = estado;
            repoPersona.Modificar(persona);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}