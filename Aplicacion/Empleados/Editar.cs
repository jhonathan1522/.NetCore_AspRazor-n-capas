using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Empleados
{
    public class Editar
    {
        public class Ejecuta : IRequest {
           public int Id { get; set; }

           public string Nombre { get; set; }

           public int? Edad { get; set; }

           public float? Altura { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Edad).NotEmpty();
                RuleFor(x => x.Altura).NotEmpty();
            }
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
                    throw new Exception("El curso no existe");
                }
                empleado.Nombre = request.Nombre ?? empleado.Nombre;
                empleado.Edad = request.Edad ?? empleado.Edad;
                empleado.Altura = request.Altura ?? empleado.Altura;

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se guardaron los cambios del empleado");

            }
        }

    }
}
