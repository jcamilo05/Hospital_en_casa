using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {
        private readonly AppContext _appContext = new AppContext();
        //Agregar Director Técnico
        DT IRepositorioDT.AddDT(DT dt)
        {
            var dtAdicionado=_appContext.DTs.Add(dt);
            _appContext.SaveChanges();
            return dtAdicionado.Entity;
        }
        //Eliminar Director Técnico
        void IRepositorioDT.DeleteDT(int idDT)
        {
            var dtEncontrado=_appContext.DTs.FirstOrDefault(p => p.ID==idDT);
            if (dtEncontrado==null)
                return;
            _appContext.DTs.Remove(dtEncontrado);
            _appContext.SaveChanges();
        }
        //Devuelve un objeto Director técnico por id
        DT IRepositorioDT.GetDT(int idDT)
        {
            return _appContext.DTs.FirstOrDefault(p => p.ID == idDT);
        }

        //----------------------------------------------------------
        //Esta parte hacia falta en el IRepositorio el getAll 
         IEnumerable<DT> IRepositorioDT.GetAllDT()
        {
            return _appContext.DTs;
        }
        //-----------------------------------------------------------
        //Recibe un objeto tipo Director Tecnico y lo actualiza
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
        //Asigna un equipo al objeto director técnico
        DT IRepositorioDT.LinkDT(int idDT, int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.ID == idEquipo);
            if (equipoEncontrado!=null)
            {
                //System.Console.WriteLine("se encontró equipo con id "+idEquipo);
                var dtEncontrado = _appContext.DTs.FirstOrDefault(d => d.ID == idDT);
                if (dtEncontrado!=null)
                {
                    //System.Console.WriteLine("se encontró DT con id "+idDT);
                    dtEncontrado.Equipo = equipoEncontrado;
                    _appContext.SaveChanges();
                } 
            }
            return null;
        }

    }
}