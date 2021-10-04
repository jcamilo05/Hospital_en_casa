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
        private readonly IRepositorioJugador _repoJugador;
        public Jugador jugador { get; set; }
        public CreateJugadoresModel(IRepositorioJugador repoJugador)
        {
            _repoJugador = repoJugador;
        }
        public void OnGet()
        {
            jugador = new Jugador();
        }
        public IActionResult OnPost(Jugador jugador)
        {
            _repoJugador.AddJugador(jugador);
            return RedirectToPage("ListJugadores");
        }
    }
}
