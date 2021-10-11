using System;
using System.Collections.Generic;
using Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {

        private readonly ApplicationContext _appContext;

        public RepositorioPersona(ApplicationContext applicationContext)
        {
            _appContext = applicationContext;
        }

        public RepositorioPersona() { }


        Empleado IRepositorioPersona.Add(Empleado empleado)
        {
            var new_persona = _appContext.Empleados.Add(empleado);
            _appContext.SaveChanges();
            return new_persona.Entity;
        }


        void IRepositorioPersona.Delete(int idPersona)
        {
            var personaEncontrado = _appContext.Empleados.FirstOrDefault(
                p => p.Id == idPersona
            );

            if(personaEncontrado == null)
            return;
            _appContext.Remove(personaEncontrado);
           _appContext.SaveChanges(); 
        }

        IEnumerable<Empleado> IRepositorioPersona.GetAll()
        {
            return _appContext.Empleados.AsNoTracking();
        }

        Empleado IRepositorioPersona.Get(int idPersona)
        {
             return _appContext.Empleados.FirstOrDefault(p =>p.Id == idPersona);
        }

        Empleado IRepositorioPersona.Update(Empleado empleado)
        {
            var personaEncontrado = _appContext.Empleados.FirstOrDefault(
                p => p.Id == empleado.Id
            );

            if(personaEncontrado!=null){
                personaEncontrado.Nombre = empleado.Nombre;
                personaEncontrado.Edad = empleado.Edad;
                personaEncontrado.Altura = empleado.Altura;
                _appContext.SaveChanges(); 

            }

            return personaEncontrado;
        }
    }
}