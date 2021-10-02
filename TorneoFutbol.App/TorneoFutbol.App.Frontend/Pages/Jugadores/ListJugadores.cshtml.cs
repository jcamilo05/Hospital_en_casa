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
    public class ListJugadoresModel : PageModel
    {
        
        private readonly IRepositorioJugador _repoJugador;
        public IEnumerable<Jugador> jugadores {get;set;}
        public ListJugadoresModel(IRepositorioJugador repoJugador)
        {
            _repoJugador= repoJugador;
        }  
        public void OnGet()
        {
            jugadores=_repoJugador.GetAllJugador();
        }
    }
}
