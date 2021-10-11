using Aplicacion.Empleados;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IMediator _mediador;
        public EmpleadosController(IMediator mediador)
        {
            _mediador = mediador;
        }

        public async Task<ActionResult<List<Empleado>>> Get() {
            return await _mediador.Send(new Consulta.ListaEmpleados());
        }
    }
}
