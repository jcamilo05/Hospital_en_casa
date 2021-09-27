using System.Collections.Generic;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
{
    public interface IRepositorioDT
    {
        IEnumerable<DT> GetAllDT();
        DT AddDT (DT dt);
        DT UpdateDT (DT dt);
        void DeleteDT (int idDT);
        DT GetDT (int idDT);
    }
}