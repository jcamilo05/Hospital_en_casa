using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioDesempeno : IRepositorioDesempeno
    {
        private readonly AppContext _appContext = new AppContext();
        Desempeno IRepositorioDesempeno.AddDesempeno(Desempeno desempeno)
        {
            var desempenoAdicionado=_appContext.Desempenos.Add(desempeno);
            _appContext.SaveChanges();
            return desempenoAdicionado.Entity;
        }

        void IRepositorioDesempeno.DeleteDesempeno(int idDesempeno)
        {
            var desempenoEncontrado=_appContext.Desempenos.FirstOrDefault(p => p.ID==idDesempeno);
            if (desempenoEncontrado==null)
                return;
            _appContext.Desempenos.Remove(desempenoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Desempeno> IRepositorioDesempeno.GetAllDesempeno()
        {
            return _appContext.Desempenos;
        }

        Desempeno IRepositorioDesempeno.GetDesempeno(int idDesempeno)
        {
            return _appContext.Desempenos.FirstOrDefault(p => p.ID == idDesempeno);
        }

        Desempeno IRepositorioDesempeno.UpdateDesempeno(Desempeno desempeno)
        {
            var desempenoEncontrado=_appContext.Desempenos.FirstOrDefault(p => p.ID == desempeno.ID);
            if (desempenoEncontrado!=null)
            {
                desempenoEncontrado.ID=desempeno.ID;
                desempenoEncontrado.PartidosJugados=desempeno.PartidosJugados;
                desempenoEncontrado.PartidosGanados=desempeno.PartidosGanados;
                desempenoEncontrado.PartidosEmpatados=desempeno.PartidosEmpatados;
                desempenoEncontrado.GolesAFavor=desempeno.GolesAFavor;
                desempenoEncontrado.GolesEnContra=desempeno.GolesEnContra;
                desempenoEncontrado.Puntos=desempeno.Puntos;
                _appContext.SaveChanges();
            }
            return desempenoEncontrado;

        }
    }
}
        
        
