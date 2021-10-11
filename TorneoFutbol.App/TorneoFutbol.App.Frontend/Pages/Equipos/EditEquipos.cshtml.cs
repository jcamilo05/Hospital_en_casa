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
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable <Municipio> municipios {get;set;}
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo { get; set; }
        

        public EditEquiposModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            municipios=_repoMunicipio.GetAllMunicipio();
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
        public IActionResult OnPost(Equipo equipo, int idMunicipio)
        {
            System.Console.WriteLine(equipo.ID);
            System.Console.WriteLine(idMunicipio);
            _repoEquipo.LinkMunicipio(equipo.ID, idMunicipio);
            _repoEquipo.UpdateEquipo(equipo);
            //return RedirectToPage("ListEquipos");
            return RedirectToPage("ListEquipos", new{ID = idMunicipio});
        }
    }
}
