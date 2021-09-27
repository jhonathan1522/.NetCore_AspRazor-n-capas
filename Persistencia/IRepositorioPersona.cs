using System.Collections.Generic;
using Dominio;
namespace Persistencia
{
    public interface IRepositorioPersona
    {
         IEnumerable<Persona> GetAllPersona();
         Persona AddPersona(Persona persona);
         Persona UpdatePersona(Persona persona);
         void DeletePersona(int idPersona);
         Persona GetPersona(int idPersona);
    }
}