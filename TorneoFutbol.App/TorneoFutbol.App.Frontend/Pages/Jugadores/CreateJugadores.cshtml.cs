using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Jugadores
{
    public class CreateJugadoresModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioJugador _repoJugador;
        public IEnumerable<Equipo> equipos { get; set; }
        public Jugador jugador { get; set; }
        public CreateJugadoresModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
        }
        public void OnGet()
        {
            jugador = new Jugador();
            equipos = _repoEquipo.GetAllEquipo();
        }
        public IActionResult OnPost(Jugador jugador, int idEquipo)
        {
            if (ModelState.IsValid)
            {
                _repoJugador.AddJugador(jugador);
                _repoJugador.LinkJugador(jugador.ID, idEquipo);
                return RedirectToPage("ListJugadores");
            }
            else
            {
                return Page();
            }
        }
    }
}
