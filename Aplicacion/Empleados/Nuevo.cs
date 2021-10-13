using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Empleados
{
    public class Nuevo
    {
        public class Ejecuta : IRequest {
            public string Nombre { get; set; }

            public int? Edad { get; set; }

            public float? Altura { get; set; }
        };


        public class EjecutaValidacion : AbstractValidator<Ejecuta> {
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
                var empleado = new Empleado
                {
                    Nombre = request.Nombre,
                    Edad = request.Edad,
                    Altura = request.Altura
                };

                _context.Empleados.Add(empleado);

                // Si devuelve 0 no realizo la transacción 
                var valor = await _context.SaveChangesAsync();

                if (valor > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el empleado");

            }
        }




    }
}
