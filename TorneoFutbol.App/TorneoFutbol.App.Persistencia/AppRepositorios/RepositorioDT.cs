using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {
        private readonly AppContext _appContext;

        public RepositorioDT(AppContext appContext)
        {
            _appContext=appContext;
        }
        DT IRepositorioDT.AddDT(DT dt)
        {
            var dtAdicionado=_appContext.DTs.Add(dt);
            _appContext.SaveChanges();
            return dtAdicionado.Entity;
        }

        void IRepositorioDT.DeleteDT(int idDT)
        {
            var dtEncontrado=_appContext.DTs.FirstOrDefault(p => p.ID==idDT);
            if (dtEncontrado==null)
                return;
            _appContext.DTs.Remove(dtEncontrado);
            _appContext.SaveChanges();
        }

        DT IRepositorioDT.GetDT(int idDT)
        {
            return _appContext.DTs.FirstOrDefault(p => p.ID == idDT);
        }

        DT IRepositorioDT.UpdateDT(DT dt)
        {
            var dtEncontrado=_appContext.DTs.FirstOrDefault(p => p.ID == dt.ID);
            if (dtEncontrado!=null)
            {
                dtEncontrado.ID=dt.ID;
                dtEncontrado.Nombre=dt.Nombre;
                dtEncontrado.Documento=dt.Documento;
                dtEncontrado.NumeroTelefono=dt.NumeroTelefono;
                

            _appContext.SaveChanges();
            }
            return dtEncontrado;

        }
    }
}