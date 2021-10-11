using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Empleados
{
    public class Consulta
    {
        public class ListaEmpleados : IRequest<List<Empleado>> {}

        public class Manejador : IRequestHandler<ListaEmpleados, List<Empleado>>
        {
            private readonly ApplicationContext _context;
            public Manejador(ApplicationContext context) {
                _context = context;
            }
            public async Task<List<Empleado>> Handle(ListaEmpleados request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Empleados.ToListAsync();
                return cursos;
            }
        }

    }
}
