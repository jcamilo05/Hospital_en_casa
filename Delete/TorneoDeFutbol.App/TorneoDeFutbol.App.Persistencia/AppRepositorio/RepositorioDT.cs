using System.Collections.Generic;
using System.Linq;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
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
            var dtAdicionado=_appContext.DirectorTecnicos.Add(dt);
            _appContext.SaveChanges();
            return dtAdicionado.Entity;
        }

        void IRepositorioDT.DeleteDT(int idDT)
        {
            var dtEncontrado=_appContext.DirectorTecnicos.FirstOrDefault(p => p.Id==idDT);
            if (dtEncontrado==null)
                return;
            _appContext.DirectorTecnicos.Remove(dtEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<DT> IRepositorioDT.GetAllDT()
        {
            return _appContext.DirectorTecnicos;
        }

        DT IRepositorioDT.GetDT(int idDT)
        {
            return _appContext.DirectorTecnicos.FirstOrDefault(p => p.Id == idDT);
        }

        DT IRepositorioDT.UpdateDT(DT dt)
        {
            var dtEncontrado=_appContext.DirectorTecnicos.FirstOrDefault(p => p.Id == dt.Id);
            if (dtEncontrado!=null)
            {
                dtEncontrado.Id=dt.Id;
                dtEncontrado.Nombre=dt.Nombre;
                dtEncontrado.Documento=dt.Documento;
                dtEncontrado.NumeroTelefono=dt.NumeroTelefono;
                

            _appContext.SaveChanges();
            }
            return dtEncontrado;

        }
    }
}