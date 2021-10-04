using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioNovedad : IRepositorioNovedad
    {

        private readonly AppContext _appContext = new AppContext();
        //Como parametro recibe un objeto tipo novedad y lo agrega al context
        Novedad IRepositorioNovedad.AddNovedad(Novedad novedad)
        {
            var novedadAdicionado = _appContext.Novedades.Add(novedad);
            _appContext.SaveChanges();
            return novedadAdicionado.Entity;
        }
        //como parametro recibe un entero que es el id a buscar luego devuelve objeto tipo novedad
        Novedad IRepositorioNovedad.GetNovedad(int idNovedad)
        {
            return _appContext.Novedades.FirstOrDefault(p => p.ID == idNovedad);
        }

        //al invocarse devuelve todos los novedades que se encuentran en el context
        IEnumerable<Novedad> IRepositorioNovedad.GetAllNovedad()
        {
            return _appContext.Novedades;
        }
        //recibe dos parametros, el id de la novedad y el id del partido, devuelve un null, pero asigna una novedad a un partido
        Novedad IRepositorioNovedad.LinkNovedadPartido(int idNovedad, int idPartido)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
            if (partidoEncontrado != null)
            {
                System.Console.WriteLine("se encontró partido con id " + idPartido);    
                var novedadEncontrada = _appContext.Novedades.FirstOrDefault(n => n.ID == idNovedad);
                if (novedadEncontrada != null)
                {
                    System.Console.WriteLine("se encontró novedad con id " + novedadEncontrada);
                    novedadEncontrada.Partido = partidoEncontrado;
                    _appContext.SaveChanges();
                    //Experimental
                    //partidoEncontrado.Novedades.Add(novedadEncontrada);
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            return null;
        }
        //recibe dos parametros, el id de la novedad y el id del jugador, devuelve un null, pero asigna una novedad a un jugador
        Novedad IRepositorioNovedad.LinkNovedadJugador(int idNovedad, int idJugador)
        {
            var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.ID == idJugador);
            if (jugadorEncontrado != null)
            {
                System.Console.WriteLine("se encontró jugador con id " + idJugador);
                var novedadEncontrada = _appContext.Novedades.FirstOrDefault(n => n.ID == idNovedad);
                if (novedadEncontrada != null)
                {
                    System.Console.WriteLine("se encontró novedad con id " + novedadEncontrada);
                    novedadEncontrada.Jugador = jugadorEncontrado;
                    _appContext.SaveChanges();
                    //Experimental
                    //partidoEncontrado.Novedades.Add(novedadEncontrada);
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            return null;
        }
        //TODO
        //averiguar si se puede poner una lista de novedades por partido
        //o devolver todas las novedades de un partido
        //consultar entity framework querying

    }
}


