using BecasCep.Models;
using BecasCep.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BecasCep.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class, IEntidad
    {
        private readonly DbContext dbContext;

        public Repositorio()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public Repositorio(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual T Traer(Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }
            else
            {
                return dbContext.Set<T>().Find(Id.Value);
            }
        }

        public IQueryable<T> TraerTodos(bool inclusiveEliminados = false)
        {
            return this.dbContext.Set<T>().Where(x => !x.Eliminado || inclusiveEliminados);
        }

        public virtual void Crear(T entidad, bool grabarCambios = true)
        {
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaEdicion = entidad.FechaCreacion;
            entidad.Eliminado = false;
            this.dbContext.Set<T>().Add(entidad);
            var errores = this.dbContext.GetValidationErrors().ToList();
            if (grabarCambios)
                try
                {
                    this.dbContext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        var error = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(error)));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var errorMessage = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                            Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(errorMessage)));
                        }
                    }
                    throw;
                }
                catch (Exception e)
                {
                    Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                    throw;
                }
        }

        public virtual void Modificar(T entidad, bool grabarCambios = true)
        {
            entidad.FechaEdicion = DateTime.Now;
            dbContext.Entry(entidad).State = EntityState.Modified;
            var errores = this.dbContext.GetValidationErrors();
            if (grabarCambios)
                try
                {
                    dbContext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        var error = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(error)));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var errorMessage = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                            Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(errorMessage)));
                        }
                    }
                    throw;
                }
                catch (Exception e)
                {
                    Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                    throw;
                }
        }

        public virtual void LoadProperty(T entidad, Expression<Func<T, object>> func)
        {
            dbContext.Entry(entidad).Reference(func).Load();
        }

        public virtual void Eliminar(T entidad, bool grabarCambios = true)
        {
            entidad.FechaEdicion = DateTime.Now;
            entidad.Eliminado = true;
            this.dbContext.Entry(entidad).State = EntityState.Modified;
            if (grabarCambios)
                try
                {
                    this.dbContext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        var error = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(error)));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var errorMessage = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                            Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(errorMessage)));
                        }
                    }
                    throw;
                }
                catch (Exception e)
                {
                    Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                    throw;
                }
        }
        public virtual void GuardarCambios(T entidad = null)
        {
            try
            {
                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var error = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(error)));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var errorMessage = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(new Exception(errorMessage)));
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                throw;
            }
        }

    }
}