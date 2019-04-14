using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecasCep.Models.Interfaces
{
    public interface IRepositorio<T> where T : class, IEntidad
    {
        T Traer(Guid? Id);
        IQueryable<T> TraerTodos(bool inclusiveEliminados);
        void Crear(T entidad, bool grabarCambios);
        void Modificar(T entidad, bool grabarCambios);
        void Eliminar(T entidad, bool grabarCambios);
        void GuardarCambios(T entidad);
    }
}