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

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> Get() {
            return await _mediador.Send(new Consulta.ListaEmpleados());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> Detalle(int id)
        {
            return await _mediador.Send(new ConsultaPorId.EmpleadoUnico { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediador.Send(new Eliminar.Ejecuta { Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data) {
            return await _mediador.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id,[FromBody] Editar.Ejecuta data) {
            data.Id = id;
            return await _mediador.Send(data);
        }


    }
}
