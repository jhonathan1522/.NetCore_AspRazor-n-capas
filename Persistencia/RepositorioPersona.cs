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


        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var new_persona = _appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return new_persona.Entity;
        }


        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var personaEncontrado = _appContext.Personas.FirstOrDefault(
                p => p.Id == idPersona
            );

            if(personaEncontrado == null)
            return;
            _appContext.Remove(personaEncontrado);
           _appContext.SaveChanges(); 
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersona()
        {
            return _appContext.Personas.AsNoTracking();
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
             return _appContext.Personas.FirstOrDefault(p =>p.Id == idPersona);
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrado = _appContext.Personas.FirstOrDefault(
                p => p.Id == persona.Id
            );

            if(personaEncontrado!=null){
                personaEncontrado.Nombre = persona.Nombre;
                personaEncontrado.Edad = persona.Edad;
                personaEncontrado.Altura = persona.Altura;
                _appContext.SaveChanges(); 

            }

            return personaEncontrado;
        }
    }
}