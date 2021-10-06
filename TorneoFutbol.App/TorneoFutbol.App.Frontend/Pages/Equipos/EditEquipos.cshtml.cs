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
    public class EditEquiposModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo { get; set; }
        public EditEquiposModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Equipo equipo)
        {
            _repoEquipo.UpdateEquipo(equipo);
            return RedirectToPage("ListEquipos");
        }
    }
}
