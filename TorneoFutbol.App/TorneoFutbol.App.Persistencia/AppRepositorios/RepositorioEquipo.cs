using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using Microsoft.EntityFrameworkCore;

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
            var equipoEncontrado=_appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado==null)
                return;
            _appContext.Equipos.Remove(equipoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Equipo> IRepositorioEquipo.GetAllEquipo()
        {
            return _appContext.Equipos
            .Include(p => p.Municipio);
        }

        Equipo IRepositorioEquipo.GetEquipo(int idEquipo)
        {
            return _appContext.Equipos.Find(idEquipo);
        }

        Equipo IRepositorioEquipo.UpdateEquipo(Equipo equipo)
        {
            var equipoEncontrado=_appContext.Equipos.Find(equipo.ID);
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
            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado!=null)
            {
                var jugadorEncontrado = _appContext.Jugadores.Find(idJugador);
                if (jugadorEncontrado!=null)
                {
                    equipoEncontrado.Jugadores.Add(jugadorEncontrado);
                    _appContext.SaveChanges();
                }
            }
        } 

        // Se añade el municipio al equipo 

        Municipio IRepositorioEquipo.LinkMunicipio(int idEquipo, int idMunicipio)
        {
            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado!=null)
            {
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado!=null)
                {
                    equipoEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                    //System.Console.WriteLine("ok");
                }
                return municipioEncontrado;
            }
            return null;
        }
    }
}