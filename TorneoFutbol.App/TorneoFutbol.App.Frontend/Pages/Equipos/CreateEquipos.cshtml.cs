using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Equipos
{
    public class CreateEquiposModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo { get; set; }
        public CreateEquiposModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public void OnGet()
        {
            equipo = new Equipo();
        }
        public IActionResult OnPost(Equipo equipo)
        {
            _repoEquipo.AddEquipo(equipo);
            return RedirectToPage("ListEquipos");
        }
    }
}
