using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;
using Microsoft.EntityFrameworkCore;

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
        public Partido GetPartido(int idPartido)
        {
            var partido =_appContext.Partidos
                    .Where(p => p.ID == idPartido)
                    .Include(p => p.EquipoVisitante)
                    .Include(p => p.EquipoLocal)
                    //.Include(p => p.MarcadorInicialVisitante)
                    //.Include(p => p.MarcadorInicialLocal)
                    .Include(p => p.Estadio)
                    //.Include(p => p.Arbitro)
                    .FirstOrDefault();
            return partido;
            //return _appContext.Partidos.Find(idPartido);
        }

        //al invocarse devuelve todos los partidos que se encuentran en el context
        IEnumerable<Partido> IRepositorioPartido.GetAllPartido()
        {
            return _appContext.Partidos
            .Include(p => p.EquipoLocal)
            .Include(p => p.EquipoVisitante);
        }
        IEnumerable<Partido> IRepositorioPartido.GetPartidoEntre(string local, string visitante)
        {
            return _appContext.Partidos
            .Where(p => p.EquipoLocal.Nombre.Contains(local) && p.EquipoVisitante.Nombre.Contains(visitante))
            .Include(p => p.Estadio);
            //.Include(p => p.EquipoVisitante);
        }

        IEnumerable<Partido> IRepositorioPartido.GetTblPartido()
        {
            return _appContext.Partidos;
        }

        //recibe como parametros el id de partido, y el id del equipo
        //luego se asigna el equipo al partido
        Partido IRepositorioPartido.LinkLocal(int idPartido, int idEquipo)
        {
            var equipoEncontrado =
                _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado != null)
            {
                var partidoEncontrado =
                    _appContext.Partidos.Find(idPartido);
                if (partidoEncontrado != null)
                {
                    partidoEncontrado.EquipoLocal = equipoEncontrado;
                    _appContext.SaveChanges();
                }
            }
            return null;
        }

        //recibe como parametros el id de partido, y el id del equipo
        //luego se asigna el equipo al partido
        Partido IRepositorioPartido.LinkVisitante(int idPartido, int idEquipo)
        {
            var equipoEncontrado =
                _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado != null)
            {
                var partidoEncontrado =
                    _appContext.Partidos.Find(idPartido);
                if (partidoEncontrado != null)
                {
                    partidoEncontrado.EquipoVisitante = equipoEncontrado;
                    _appContext.SaveChanges();
                }
            }
            return null;
        }

        //recibe como parametros el id del partido y el id del estadio a asignar

        Partido
        IRepositorioPartido.LinkEstadioPartido(int idPartido, int idEstadio)
        {
            var estadioEncontrado =
                _appContext.Estadios.Find(idEstadio);
            if (estadioEncontrado != null)
            {
                var partidoEncontrado =
                    _appContext.Partidos.Find(idPartido);
                if (partidoEncontrado != null)
                {
                    partidoEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                }
            }
            return null;
        }

        //recibe como parametros el id del partido y el id del arbitro a asignar

        Partido IRepositorioPartido.LinkArbitroPartido(int idPartido, int idArbitro)
        {
            var arbitroEncontrado =
                _appContext.Arbitros.Find(idArbitro);
            if (arbitroEncontrado != null)
            {
                var partidoEncontrado =
                    _appContext.Partidos.Find(idPartido);
                if (partidoEncontrado != null)
                {
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                    _appContext.SaveChanges();
                }
            }
            return null;
        }
    }
}
