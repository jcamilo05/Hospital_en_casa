using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> GetAllMunicipio();
        Municipio AddMunicipio (Municipio municipio);
        Municipio UpdateMunicipio (Municipio municipio);
        void DeleteMunicipio (int idMunicipio);
        Municipio GetMunicipio (int idMunicipio);
        Municipio LinkEstadio (int idMunicipio, int idEstadio);
    }
}