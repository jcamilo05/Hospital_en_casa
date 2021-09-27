using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioDT
    {
        DT AddDT (DT dt);
        DT UpdateDT (DT dt);
        void DeleteDT (int idDT);
        DT GetDT (int idDT);
    }
}