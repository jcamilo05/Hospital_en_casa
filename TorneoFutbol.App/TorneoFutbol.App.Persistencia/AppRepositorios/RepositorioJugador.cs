using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        /*private readonly AppContext _appContext;

        public RepositorioJugador(AppContext appContext)
        {
            _appContext=appContext;
        }*/
        private readonly AppContext _appContext = new AppContext();
        Jugador IRepositorioJugador.AddJugador(Jugador jugador)
        {
            var jugadorAdicionado=_appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdicionado.Entity;
        }

        void IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(p => p.ID==idJugador);
            if (jugadorEncontrado==null)
                return;
            _appContext.Jugadores.Remove(jugadorEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Jugador> IRepositorioJugador.GetAllJugador()
        {
            return _appContext.Jugadores;
        }

        Jugador IRepositorioJugador.GetJugador(int idJugador)
        {
            return _appContext.Jugadores.FirstOrDefault(p => p.ID == idJugador);
        }

        Jugador IRepositorioJugador.UpdateJugador(Jugador jugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(p => p.ID == jugador.ID);
            if (jugadorEncontrado!=null)
            {
                jugadorEncontrado.ID=jugador.ID;
                jugadorEncontrado.Nombre=jugador.Nombre;
                jugadorEncontrado.Documento=jugador.Documento;
                jugadorEncontrado.NumeroTelefono=jugador.NumeroTelefono;
                jugadorEncontrado.Numero=jugador.Numero;
                jugadorEncontrado.Posicion=jugador.Posicion;

            _appContext.SaveChanges();
            }
            return jugadorEncontrado;

        }
    }
}
        
        
