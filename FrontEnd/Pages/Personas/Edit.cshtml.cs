using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;

namespace MyApp.Namespace
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPersona _repo;

        public Persona Persona { get; set; }
        
        public EditModel(IRepositorioPersona repositorioPersona)
        {
            _repo = repositorioPersona;
        }
        public void OnGet(int id)
        {
            Persona = _repo.GetPersona(id);
        }
    }
}
