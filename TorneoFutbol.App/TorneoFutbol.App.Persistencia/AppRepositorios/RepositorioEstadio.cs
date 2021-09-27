using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEstadio : IRepositorioEstadio
    {
        private readonly AppContext _appContext;

        public RepositorioEstadio(AppContext appContext)
        {
            _appContext=appContext;
        }
        Estadio IRepositorioEstadio.AddEstadio(Estadio estadio)
        {
            var estadioAdicionado=_appContext.Estadios.Add(estadio);
            _appContext.SaveChanges();
            return estadioAdicionado.Entity;
        }

        void IRepositorioEstadio.DeleteEstadio(int idEstadio)
        {
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(p => p.ID==idEstadio);
            if (estadioEncontrado==null)
                return;
            _appContext.Estadios.Remove(estadioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Estadio> IRepositorioEstadio.GetAllEstadio()
        {
            return _appContext.Estadios;
        }

        Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
        {
            return _appContext.Estadios.FirstOrDefault(p => p.ID == idEstadio);
        }

        Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(p => p.ID == estadio.ID);
            if (estadioEncontrado!=null)
            {
                estadioEncontrado.ID=estadio.ID;
                estadioEncontrado.Nombre=estadio.Nombre;
                estadioEncontrado.Direccion=estadio.Direccion;
                

            _appContext.SaveChanges();
            }
            return estadioEncontrado;

        }
    }
}
        
        