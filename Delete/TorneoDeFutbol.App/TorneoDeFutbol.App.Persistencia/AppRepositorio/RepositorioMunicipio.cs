using System.Collections.Generic;
using System.Linq;
using TorneoDeFutbol.App.Dominio;

namespace TorneoDeFutbol.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly AppContext _appContext;

        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext=appContext;
        }
        Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
            var municipioAdicionado=_appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdicionado.Entity;
        }

        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(p => p.Id==idMunicipio);
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
            return _appContext.Municipios.FirstOrDefault(p => p.Id == idMunicipio);
        }

        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado=_appContext.Municipios.FirstOrDefault(p => p.Id == municipio.Id);
            if (municipioEncontrado!=null)
            {
                municipioEncontrado.Id=municipio.Id;
                municipioEncontrado.Nombre=municipio.Nombre;
                municipioEncontrado.Departamento=municipio.Departamento;
                

            _appContext.SaveChanges();
            }
            return municipioEncontrado;

        }
    }
}
        
        
