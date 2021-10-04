using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Estadios
{
    public class CreateEstadiosModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio { get; set; }
        public CreateEstadiosModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }
        public void OnGet()
        {
            estadio = new Estadio();
        }
        public IActionResult OnPost(Estadio estadio)
        {
            _repoEstadio.AddEstadio(estadio);
            return RedirectToPage("ListEstadios");
        }
    }
}
