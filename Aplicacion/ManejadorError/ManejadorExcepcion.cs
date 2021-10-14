using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ManejadorError
{
    public class ManejadorExcepcion: Exception
    {
        public HttpStatusCode Codigo { get; set; }
        public object Errores { get; set; }
        public ManejadorExcepcion(HttpStatusCode codigo, object errores = null)
        {
            Codigo = codigo;
            Errores = errores;
        }
    }
}
