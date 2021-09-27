using System.Collections.Generic;
using Dominio;
namespace Persistencia
{
    public interface IRepositorioPersona
    {
         IEnumerable<Persona> GetAllPersona();
         Persona addPersona(Persona persona);
         Persona updatePersona(Persona persona);
         void DeletePersona(int idPersona);
         Persona GetPersona(int idPersona);
    }
}