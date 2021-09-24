using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioDirectorTecnico : IRepositorioDirectorTecnico
    {
        private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();

        DirectorTecnico IRepositorioDirectorTecnico.AddDirectorTecnico(DirectorTecnico directorTecnico)
        {
            var directorTecnicoAdded = _appContext.DirectorTecnicos.Add(directorTecnico);
            _appContext.SaveChanges();
            return directorTecnicoAdded.Entity; 
        }

        void IRepositorioDirectorTecnico.DeleteDirectorTecnico(int idDirectorTecnico)
        {
            var directorTecnicofound = _appContext.DirectorTecnicos.FirstOrDefault(p => p.ID == idDirectorTecnico);
            if (directorTecnicofound == null)
                return;
            _appContext.DirectorTecnicos.Remove(directorTecnicofound);
            _appContext.SaveChanges();
        }

        IEnumerable<DirectorTecnico> IRepositorioDirectorTecnico.GetAllDirectorTecnicos()
        {
            return _appContext.DirectorTecnicos;
        }
        
        DirectorTecnico IRepositorioDirectorTecnico.GetDirectorTecnico(int idDirectorTecnico)
        {
            return _appContext.DirectorTecnicos.FirstOrDefault(p => p.ID == idDirectorTecnico);
        }
        DirectorTecnico IRepositorioDirectorTecnico.UpdateDirectorTecnico(DirectorTecnico directorTecnico)
        {
            var directorTecnicofound = _appContext.DirectorTecnicos.FirstOrDefault(p => p.ID == directorTecnico.ID);
            if (directorTecnicofound != null)
            {
                directorTecnicofound.Nombre = directorTecnico.Nombre;
                directorTecnicofound.Documento = directorTecnico.Documento;
                directorTecnicofound.NumeroTelefono = directorTecnico.NumeroTelefono;

                _appContext.SaveChanges();
            }

            return directorTecnicofound;
        }

    }
}
