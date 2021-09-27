using System;
using System.Collections.Generic;
using Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {

        private readonly PersonaContext _appContext;

        public RepositorioPersona(PersonaContext applicationContext)
        {
            _appContext = applicationContext;
        }

        public RepositorioPersona() { }


        Persona IRepositorioPersona.addPersona(Persona persona)
        {
            var new_persona = _appContext.personas.Add(persona);
            _appContext.SaveChanges();
            return new_persona.Entity;
        }


        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(
                p => p.Id == idPersona
            );

            if(personaEncontrado == null)
            return;
            _appContext.Remove(personaEncontrado);
           _appContext.SaveChanges(); 
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersona()
        {
            return _appContext.personas.AsNoTracking();
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
             return _appContext.personas.FirstOrDefault(p =>p.Id == idPersona);
        }

        Persona IRepositorioPersona.updatePersona(Persona persona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(
                p => p.Id == persona.Id
            );

            if(personaEncontrado!=null){
                personaEncontrado.Nombre = persona.Nombre;
                personaEncontrado.edad = persona.edad;
                personaEncontrado.Altura = persona.Altura;
                _appContext.SaveChanges(); 

            }

            return personaEncontrado;
        }
    }
}