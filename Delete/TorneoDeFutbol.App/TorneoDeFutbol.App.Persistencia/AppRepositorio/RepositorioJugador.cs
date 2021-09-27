using System.Collections.Generic;
using System.Linq;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly AppContext _appContext;

        public RepositorioJugador(AppContext appContext)
        {
            _appContext=appContext;
        }
        Jugador IRepositorioJugador.AddJugador(Jugador jugador)
        {
            var jugadorAdicionado=_appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdicionado.Entity;
        }

        void IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(p => p.Id==idJugador);
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
            return _appContext.Jugadores.FirstOrDefault(p => p.Id == idJugador);
        }

        Jugador IRepositorioJugador.UpdateJugador(Jugador jugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(p => p.Id == jugador.Id);
            if (jugadorEncontrado!=null)
            {
                jugadorEncontrado.Id=jugador.Id;
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
        
        
