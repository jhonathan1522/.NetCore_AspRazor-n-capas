using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Empleados
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {

            private readonly ApplicationContext _context;
            public Manejador(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var empleado = await _context.Empleados.FindAsync(request.Id);

                if (empleado == null) {
                    //throw new Exception("No se puede eliminar el empleado");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el empleado" });
                }
                _context.Remove(empleado);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron guardar los cambios");

            }
        }
    }
}
