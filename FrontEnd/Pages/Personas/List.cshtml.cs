using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace MyApp.Namespace
{
    public class ListModel : PageModel
    {

        private readonly IRepositorioPersona _repo;

        public IEnumerable<Empleado> Personas { get; set; }
        
        public ListModel(IRepositorioPersona repositorioPersona)
        {
            _repo = repositorioPersona;
        }
        
        public void OnGet()
        {
            Personas = _repo.GetAll();
        }
    }
}
