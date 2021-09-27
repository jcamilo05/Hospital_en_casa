using System.Collections.Generic;
using System.Linq;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
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
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(p => p.Id==idEstadio);
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
            return _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
        }

        Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var estadioEncontrado=_appContext.Estadios.FirstOrDefault(p => p.Id == estadio.Id);
            if (estadioEncontrado!=null)
            {
                estadioEncontrado.Id=estadio.Id;
                estadioEncontrado.Nombre=estadio.Nombre;
                estadioEncontrado.Direccion=estadio.Direccion;
                estadioEncontrado.Ciudad=estadio.Ciudad;
                

            _appContext.SaveChanges();
            }
            return estadioEncontrado;

        }
    }
}
        
        