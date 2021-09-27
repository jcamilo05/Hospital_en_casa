using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {
        private readonly AppContext _appContext;

        public RepositorioArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }
        Arbitro IRepositorioArbitro.AddArbitro(Arbitro arbitro)
        {
            var arbitroAdicionado=_appContext.Arbitros.Add(arbitro);
            _appContext.SaveChanges();
            return arbitroAdicionado.Entity;
        }

        void IRepositorioArbitro.DeleteArbitro(int idArbitro)
        {
            var arbitroEncontrado=_appContext.Arbitros.FirstOrDefault(p => p.ID==idArbitro);
            if (arbitroEncontrado==null)
                return;
            _appContext.Arbitros.Remove(arbitroEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Arbitro> IRepositorioArbitro.GetAllArbitro()
        {
            return _appContext.Arbitros;
        }

        Arbitro IRepositorioArbitro.GetArbitro(int idArbitro)
        {
            return _appContext.Arbitros.FirstOrDefault(p => p.ID == idArbitro);
        }

        Arbitro IRepositorioArbitro.UpdateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado=_appContext.Arbitros.FirstOrDefault(p => p.ID == arbitro.ID);
            if (arbitroEncontrado!=null)
            {
                arbitroEncontrado.ID=arbitro.ID;
                arbitroEncontrado.Nombre=arbitro.Nombre;
                arbitroEncontrado.Documento=arbitro.Documento;
                arbitroEncontrado.NumeroTelefono=arbitro.NumeroTelefono;
                arbitroEncontrado.Colegio=arbitro.Colegio;

            _appContext.SaveChanges();
            }
            return arbitroEncontrado;

        }
    }
}
        
        
