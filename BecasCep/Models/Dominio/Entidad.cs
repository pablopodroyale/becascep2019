using BecasCep.Helpers;
using BecasCep.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Dominio
{
    public class Entidad : IEntidad
    {

        [ScaffoldColumn(false)]
        private Guid guid { get; set; }
        //private Guid guid = default(Guid);

        [Key]
        public Guid Id
        {
            get
            {
                if (this.guid == default(Guid) || this.guid == null)
                    this.guid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd);
                return guid;
            }

            set { this.guid = value; }
        }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }

        //[ScaffoldColumn(false)]
        //[Display(Name = "Autor")]
        //[Required(ErrorMessage = "Debe ingresar el Autor")]
        //public virtual Pelicula Autor { get; set; }

        [ScaffoldColumn(false)]
        private DateTime fechaCreacion = default(DateTime);

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion
        {
            get
            {
                return (this.fechaCreacion == default(DateTime))
                   ? DateTime.Now
                   : this.fechaCreacion;
            }

            set { this.fechaCreacion = value; }
        }

        [ScaffoldColumn(false)]
        private DateTime fechaEdicion = default(DateTime);

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha de última edición")]
        public DateTime FechaEdicion
        {
            get
            {
                return (this.fechaEdicion == default(DateTime))
                   ? DateTime.Now
                   : this.fechaEdicion;
            }

            set { this.fechaEdicion = value; }
        }

        [Display(Name = "Eliminado")]
        [Required]
        public bool Eliminado { get; set; }

        public int retornarString()
        {
            return 1;
        }
    }
    public class EntidadComparer : IEqualityComparer<Entidad>
    {
        public bool Equals(Entidad x, Entidad y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Entidad obj)
        {
            return obj.GetHashCode();
        }
    }
}