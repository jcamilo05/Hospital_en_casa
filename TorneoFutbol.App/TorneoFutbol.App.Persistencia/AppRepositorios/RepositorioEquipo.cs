using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        /*private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }*/
        private readonly AppContext _appContext = new AppContext();
        Equipo IRepositorioEquipo.AddEquipo(Equipo equipo)
        {
            var equipoAdicionado=_appContext.Equipos.Add(equipo);
            _appContext.SaveChanges();
            return equipoAdicionado.Entity;
        }

        void IRepositorioEquipo.DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado=_appContext.Equipos.FirstOrDefault(p => p.ID==idEquipo);
            if (equipoEncontrado==null)
                return;
            _appContext.Equipos.Remove(equipoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Equipo> IRepositorioEquipo.GetAllEquipo()
        {
            return _appContext.Equipos;
        }

        Equipo IRepositorioEquipo.GetEquipo(int idEquipo)
        {
            return _appContext.Equipos.FirstOrDefault(p => p.ID == idEquipo);
        }

        Equipo IRepositorioEquipo.UpdateEquipo(Equipo equipo)
        {
            var equipoEncontrado=_appContext.Equipos.FirstOrDefault(p => p.ID == equipo.ID);
            if (equipoEncontrado!=null)
            {
                equipoEncontrado.ID=equipo.ID;
                equipoEncontrado.Nombre=equipo.Nombre;
                //equipoEncontrado.Director=equipo.Director;
                equipoEncontrado.Municipio=equipo.Municipio;
                equipoEncontrado.Jugadores=equipo.Jugadores;

            _appContext.SaveChanges();
            }
            return equipoEncontrado;

        }
        void IRepositorioEquipo.AsignarJugador(int idEquipo, int idJugador)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.ID == idEquipo);
            if (equipoEncontrado!=null)
            {
                var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.ID == idJugador);
                if (jugadorEncontrado!=null)
                {
                    equipoEncontrado.Jugadores.Add(jugadorEncontrado);
                    _appContext.SaveChanges();
                }
            }
        } 

        
    }
}
        
        
