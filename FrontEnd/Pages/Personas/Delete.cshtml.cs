using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.Personas
{
    public class DeleteModel : PageModel
    {

        private readonly IRepositorioPersona _repo;

        public Persona Persona { get; set; }

        public DeleteModel(IRepositorioPersona repositorioPersona)
        {
            _repo = repositorioPersona;
        }
        public void OnGet(int id)
        {
            Persona = _repo.GetPersona(id);
        }

        public void OnPost(int id)
        {
                _repo.DeletePersona(id);
        }

        public void Prueba(int id) {
            Console.WriteLine("Hola");
        }

    }
}
