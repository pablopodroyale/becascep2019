using BecasCep.Models.Enums;
using BecasCep.Models.ViewModels.General;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecasCep.Models.ViewModels.Usuario
{
    public class UsuarioABMViewModel : EntidadViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("CheckExistingEmail", "Account", HttpMethod = "POST", ErrorMessage = "El email ya existe")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public SelectList RolesDisponibles { get; set; }
        public List<RoleEnum> RolesSeleccionados { get; set; }
        public List<RoleEnum> RolesDisponibleEdit { get; set; }

        public UsuarioABMViewModel()
        {
            LlenarListas();
            this.RolesSeleccionados = new List<RoleEnum>();
        }

        public UsuarioABMViewModel(Dominio.Usuario model, ApplicationUserManager userManager)
        {
            Id = model.Id;
            Nombre = model.Nombre;
            NickName = model.NickName;
            Email = model.ApplicationUser.Email;
            //PassWord = model.ApplicationUser.PasswordHash;
            RolesDisponibleEdit = new List<RoleEnum>();
            this.RolesSeleccionados = new List<RoleEnum>();
            llenarRolesSeleccionados(model, userManager);
        }

        private void llenarRolesSeleccionados(Dominio.Usuario model, ApplicationUserManager userManager)
        {
            var todosLosRoles = new ApplicationDbContext().Roles.ToDictionary(r => r.Name);
            List<string> rolesUsuario = new List<string>();
            userManager.GetRoles(model.ApplicationUser.Id).ToArray().Cast<string>().ToList().ForEach(r => rolesUsuario.Add(todosLosRoles[r].Name));
            foreach (var item in rolesUsuario)
            {
                RolesSeleccionados.Add((RoleEnum)Enum.Parse(typeof(RoleEnum), item));
            }
            for (int i = 0; i < todosLosRoles.Count; i++)
            {
                RolesDisponibleEdit.Add((RoleEnum)Enum.Parse(typeof(RoleEnum), todosLosRoles.Keys.ElementAt(i)));
            }
        }

        private void LlenarListas()
        {
            this.RolesDisponibles = new SelectList(Enum.GetValues(typeof(Enums.RoleEnum)));
        }
    }
}