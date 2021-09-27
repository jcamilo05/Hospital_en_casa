using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEstadio : IRepositorioEstadio
    {
        private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();

        Estadio IRepositorioEstadio.AddEstadio(Estadio estadio)
        {
            var estadioAdded = _appContext.Estadios.Add(estadio);
            _appContext.SaveChanges();
            return estadioAdded.Entity; 
        }

        void IRepositorioEstadio.DeleteEstadio(int idEstadio)
        {
            var estadiofound = _appContext.Estadios.FirstOrDefault(p => p.ID == idEstadio);
            if (estadiofound == null)
                return;
            _appContext.Estadios.Remove(estadiofound);
            _appContext.SaveChanges();
        }

        IEnumerable<Estadio> IRepositorioEstadio.GetAllEstadios()
        {
            return _appContext.Estadios;
        }
        
        Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
        {
            return _appContext.Estadios.FirstOrDefault(p => p.ID == idEstadio);
        }
        Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var estadiofound = _appContext.Estadios.FirstOrDefault(p => p.ID == estadio.ID);
            if (estadiofound != null)
            {
                estadiofound.Nombre = estadio.Nombre;
                estadiofound.Direccion = estadio.Direccion;

                _appContext.SaveChanges();
            }

            return estadiofound;
        }

    }
}
