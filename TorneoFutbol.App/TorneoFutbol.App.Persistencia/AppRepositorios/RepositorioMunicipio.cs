using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        /*private readonly AppContext _appContext;

        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext=appContext;
        }*/
        private readonly AppContext _appContext = new AppContext();
        Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
            var municipioAdicionado=_appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdicionado.Entity;
        }

        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(p => p.ID==idMunicipio);
            if (municipioEncontrado==null)
                return;
            _appContext.Municipios.Remove(municipioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipio()
        {
            return _appContext.Municipios;
        }

        Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(p => p.ID == idMunicipio);
        }

        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(p => p.ID == municipio.ID);
            if (municipioEncontrado!=null)
            {
                municipioEncontrado.ID=municipio.ID;
                municipioEncontrado.Nombre=municipio.Nombre;
                municipioEncontrado.Departamento=municipio.Departamento;
                

            _appContext.SaveChanges();
            }
            return municipioEncontrado;
        }
        Municipio IRepositorioMunicipio.LinkEstadio(int idMunicipio, int idEstadio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(e => e.ID == idEstadio);
            if (estadioEncontrado!=null)
            {
                var municipioEncontrado = _appContext.Municipios.FirstOrDefault(p => p.ID == idMunicipio);
                if (municipioEncontrado!=null)
                {
                    municipioEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                }     
            } 
            return null;
        }
    }
}
        
        
