using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> GetAllEquipo();
        Equipo AddEquipo (Equipo equipo);
        Equipo UpdateEquipo (Equipo equipo);
        void DeleteEquipo (int idEquipo);
        Equipo GetEquipo (int idEquipo);
    }
}