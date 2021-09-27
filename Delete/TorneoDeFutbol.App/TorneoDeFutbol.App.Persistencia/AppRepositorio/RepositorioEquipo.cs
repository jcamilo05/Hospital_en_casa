using System.Collections.Generic;
using System.Linq;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }
        Equipo IRepositorioEquipo.AddEquipo(Equipo equipo)
        {
            var equipoAdicionado=_appContext.Equipos.Add(equipo);
            _appContext.SaveChanges();
            return equipoAdicionado.Entity;
        }

        void IRepositorioEquipo.DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado=_appContext.Equipos.FirstOrDefault(p => p.Id==idEquipo);
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
            return _appContext.Equipos.FirstOrDefault(p => p.Id == idEquipo);
        }

        Equipo IRepositorioEquipo.UpdateEquipo(Equipo equipo)
        {
            var equipoEncontrado=_appContext.Equipos.FirstOrDefault(p => p.Id == equipo.Id);
            if (equipoEncontrado!=null)
            {
                equipoEncontrado.Id=equipo.Id;
                equipoEncontrado.Nombre=equipo.Nombre;
                equipoEncontrado.Director=equipo.Director;
                equipoEncontrado.Municipio=equipo.Municipio;
                equipoEncontrado.Jugadores=equipo.Jugadores;

            _appContext.SaveChanges();
            }
            return equipoEncontrado;

        }
    }
}
        
        
