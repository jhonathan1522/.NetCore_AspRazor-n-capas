using Aplicacion.Seguridad;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UsuarioController: MiControllerBase
    {
        //http:localhost:port/api/Usuario/login
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta parametros) {
            return await Mediator.Send(parametros);
        }

    }
}
