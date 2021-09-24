using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();

        Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
            var municipioAdded = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdded.Entity; 
        }

        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipiofound = _appContext.Municipios.FirstOrDefault(p => p.ID == idMunicipio);
            if (municipiofound == null)
                return;
            _appContext.Municipios.Remove(municipiofound);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipios()
        {
            return _appContext.Municipios;
        }
        
        Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(p => p.ID == idMunicipio);
        }
        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var municipiofound = _appContext.Municipios.FirstOrDefault(p => p.ID == municipio.ID);
            if (municipiofound != null)
            {
                municipiofound.Nombre = municipio.Nombre;
                municipiofound.Documento = municipio.Documento;
                municipiofound.NumeroTelefono = municipio.NumeroTelefono;

                _appContext.SaveChanges();
            }

            return municipiofound;
        }

    }
}
