using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {

        private readonly AppContext _appContext = new AppContext();
        //Como parametro recibe un objeto tipo partido y lo agrega al context
        Partido IRepositorioPartido.AddPartido(Partido partido)
        {
            var partidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();
            return partidoAdicionado.Entity;
        }
        //como parametro recibe un entero que es el id a buscar luego devuelve objeto tipo partido
        Partido IRepositorioPartido.GetPartido(int idPartido)
        {
            return _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
        }

        //al invocarse devuelve todos los partidos que se encuentran en el context
        IEnumerable<Partido> IRepositorioPartido.GetAllPartido()
        {
            return _appContext.Partidos;
        }

        //recibe como parametros el id de partido, y el id del equipo
        //luego se asigna el equipo al partido
        Partido IRepositorioPartido.LinkLocal(int idPartido, int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.ID == idEquipo);
            if (equipoEncontrado != null)
            {
                System.Console.WriteLine("se encontró equipo con id "+idEquipo);
                var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
                if (partidoEncontrado != null)
                {
                    System.Console.WriteLine("se encontró partido con id "+idPartido);
                    partidoEncontrado.EquipoLocal = equipoEncontrado;
                    _appContext.SaveChanges();
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            return null;
        }
        //recibe como parametros el id de partido, y el id del equipo
        //luego se asigna el equipo al partido
        Partido IRepositorioPartido.LinkVisitante(int idPartido, int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.ID == idEquipo);
            if (equipoEncontrado != null)
            {
                System.Console.WriteLine("se encontró equipo con id "+idEquipo);
                var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
                if (partidoEncontrado != null)
                {
                    System.Console.WriteLine("se encontró partido con id "+idPartido);
                    partidoEncontrado.EquipoVisitante = equipoEncontrado;
                    _appContext.SaveChanges();
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            return null;
        }
        //recibe como parametros el id del partido y el id del estadio a asignar 
        Partido IRepositorioPartido.LinkEstadioPartido(int idPartido, int idEstadio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(e => e.ID == idEstadio);
            if (estadioEncontrado != null)
            {
                System.Console.WriteLine("se encontró estadio con id " + idEstadio);
                var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
                if (partidoEncontrado != null)
                {
                    System.Console.WriteLine("se encontró partido con id " + idPartido);
                    partidoEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            //System.Console.WriteLine("saliendo de link estadio");
            return null;
        }
        //recibe como parametros el id del partido y el id del arbitro a asignar 
        Partido IRepositorioPartido.LinkArbitroPartido(int idPartido, int idArbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(a => a.ID == idArbitro);
            if (arbitroEncontrado != null)
            {
                System.Console.WriteLine("se encontró arbitro con id " + idArbitro);
                var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.ID == idPartido);
                if (partidoEncontrado != null)
                {
                    System.Console.WriteLine("se encontró partido con id " + idPartido);
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                    _appContext.SaveChanges();
                    System.Console.WriteLine("se linkeo correctamente");
                }
            }
            //System.Console.WriteLine("saliendo de link estadio");
            return null;
        }
    }
}


