using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
     public interface IRepositorioArbitro
     {
         IEnumerable<Arbitro> GetAllArbitro();
         IEnumerable<Arbitro> GetArbitroOnColegio(string col);
         Arbitro AddArbitro (Arbitro arbitro);
         Arbitro UpdateArbitro (Arbitro arbitro);
         void DeleteArbitro (int idArbitro);
         Arbitro GetArbitro (int idArbitro);
     }
}