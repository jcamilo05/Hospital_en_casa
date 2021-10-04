using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioJugador
    {
        IEnumerable<Jugador> GetAllJugador();
        Jugador AddJugador (Jugador jugador);
        Jugador UpdateJugador (Jugador jugador);
        void DeleteJugador (int idJugador);
        Jugador GetJugador (int idJugador);
        Jugador LinkJugador(int idJugador, int idEquipo);
    }
}