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
    public class ConsultaPorId
    {
        public class EmpleadoUnico : IRequest<Empleado> {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<EmpleadoUnico, Empleado>
        {
            private readonly ApplicationContext _context;
            public Manejador(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Empleado> Handle(EmpleadoUnico request, CancellationToken cancellationToken)
            {
                var curso = await _context.Empleados.FindAsync(request.Id);
                if (curso == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el empleado" });
                }
                return curso;
            }
        }
    }
}
