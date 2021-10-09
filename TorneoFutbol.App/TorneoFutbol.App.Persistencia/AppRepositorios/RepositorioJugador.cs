using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly AppContext _appContext = new AppContext();

        //Recibe un objeto tipo jugador, y lo agrega al appcontext
        Jugador IRepositorioJugador.AddJugador(Jugador jugador)
        {
            var jugadorAdicionado=_appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdicionado.Entity;
        }
        //Recibe un objeto tipo jugador, y lo elimina del appcontext
        void IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(p => p.ID==idJugador);
            if (jugadorEncontrado==null)
                return;
            _appContext.Jugadores.Remove(jugadorEncontrado);
            _appContext.SaveChanges();
        }
        //devuelve todo el appcontext de jugadores
        IEnumerable<Jugador> IRepositorioJugador.GetAllJugador()
        {
            return _appContext.Jugadores;
        }
        //Recibe un id de jugador, lo busca en el appcontext y devuelve un objeto de tipo jugador
        Jugador IRepositorioJugador.GetJugador(int idJugador)
        {
            return _appContext.Jugadores.FirstOrDefault(p => p.ID == idJugador);
        }
        //Recibe un objeto tipo jugador, actualiza el jugador y devuelve el objeto
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
        Equipo IRepositorioJugador.LinkJugador(int idJugador, int idEquipo)
        {
            var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(j => j.ID == idJugador);
            if (jugadorEncontrado!=null)
            {
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.ID == idEquipo);
                if (equipoEncontrado!=null)
                {
                    jugadorEncontrado.Equipo = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
    }
}
        
        
