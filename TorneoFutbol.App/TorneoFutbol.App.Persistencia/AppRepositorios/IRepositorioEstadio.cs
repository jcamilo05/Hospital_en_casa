using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        IEnumerable<Estadio> GetAllEstadio();
        Estadio AddEstadio (Estadio estadio);
        Estadio UpdateEstadio (Estadio estadio);
        void DeleteEstadio (int idEstadio);
        Estadio GetEstadio (int idEstadio);
    }
}