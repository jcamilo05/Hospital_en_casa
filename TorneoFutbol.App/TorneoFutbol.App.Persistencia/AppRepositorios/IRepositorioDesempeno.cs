using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioDesempeno
    {
        IEnumerable<Desempeno> GetAllDesempeno();
        Desempeno AddDesempeno (Desempeno desempeno);
        Desempeno UpdateDesempeno (Desempeno desempeno);
        void DeleteDesempeno (int idDesempeno);
        Desempeno GetDesempeno (int idDesempeno);
    }
}