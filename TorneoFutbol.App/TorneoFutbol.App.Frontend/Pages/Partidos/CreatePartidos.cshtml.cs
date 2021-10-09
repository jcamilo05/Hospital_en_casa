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
    public class CreatePartidosModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEstadio _repoEstadio;
        public Partido partido { get; set; }
        public IEnumerable<Equipo> equipos { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }
        public CreatePartidosModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo, IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            _repoEstadio = repoEstadio;
        }
        public void OnGet()
        {
            partido = new Partido();
            equipos = _repoEquipo.GetAllEquipo();
            estadios = _repoEstadio.GetAllEstadio();
        }
        public IActionResult OnPost(Partido partido, int idEquipoL, int idEquipoV, int idEstadio)
        {
            _repoPartido.AddPartido(partido);
            _repoPartido.LinkVisitante(partido.ID,idEquipoV);
            _repoPartido.LinkLocal(partido.ID,idEquipoL);
            _repoPartido.LinkEstadioPartido(partido.ID, idEstadio);

            return RedirectToPage("ListPartidos");
        }
    }
}
