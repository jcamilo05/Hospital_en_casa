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
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Equipo equipo {get;set;}
        public IEnumerable <Municipio> municipios {get;set;}
        public AddMunicipioModel (IRepositorioEquipo repoEquipo,IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            municipios = _repoMunicipio.GetAllMunicipio();
        }
         public IActionResult OnPost(int idEquipo, int idMunicipio)
        {
            _repoEquipo.LinkMunicipio(idEquipo, idMunicipio);
            return RedirectToPage("DetailsEquipos", new{ID = idMunicipio});
        }

    }
}
