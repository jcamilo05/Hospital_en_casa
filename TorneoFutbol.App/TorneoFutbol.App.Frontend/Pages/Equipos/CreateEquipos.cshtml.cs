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
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable <Municipio> municipios {get;set;}
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo { get; set; }
        public CreateEquiposModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
            _repoEquipo = repoEquipo;
        }
        public void OnGet()
        {
            municipios=_repoMunicipio.GetAllMunicipio();
            equipo = new Equipo();
        }
        public IActionResult OnPost(Equipo equipo, int idMunicipio)
        {
            _repoEquipo.AddEquipo(equipo);
            _repoEquipo.LinkMunicipio(equipo.ID, idMunicipio);
            return RedirectToPage("ListEquipos");
        }
    }
}
