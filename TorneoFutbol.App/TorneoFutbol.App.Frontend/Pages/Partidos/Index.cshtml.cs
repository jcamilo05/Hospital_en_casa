using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Partidos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioPartido _repoPartido;
        public Municipio municipio { get; set; }
        public Partido partido {get; set;}
        public IEnumerable<Equipo> equipos { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }

        public IndexModel(IRepositorioEquipo repoEquipo, IRepositorioEstadio repoEstadio, IRepositorioPartido repoPartido)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            _repoEstadio = repoEstadio;
        } 
        public IActionResult OnGet(int id)
        {
            equipos = _repoEquipo.GetAllEquipo();
            estadios = _repoEstadio.GetAllEstadio();   
            partido = _repoPartido.GetPartido(id);
            //municipio = _repoMunicipio.GetMunicipio(id);
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Partido partido)
        {
            //_repoMunicipio.UpdateMunicipio(municipio);
            //return RedirectToPage("ListMunicipios");
            //return Pages();
            return RedirectToPage("ListPartidos");
        }
    }
}
