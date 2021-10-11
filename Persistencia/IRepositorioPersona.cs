using System.Collections.Generic;
using Dominio;
namespace Persistencia
{
    public interface IRepositorioPersona
    {
         IEnumerable<Empleado> GetAll();
         Empleado Add(Empleado empleado);
         Empleado Update(Empleado empleado);
         void Delete(int idEmpleado);
         Empleado Get(int idEmpleado);
    }
}