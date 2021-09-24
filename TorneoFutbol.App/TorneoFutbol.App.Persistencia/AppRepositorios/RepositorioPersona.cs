using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();
        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAdded = _appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return personaAdded.Entity; 
        }

        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var personafound = _appContext.Personas.FirstOrDefault(p => p.ID == idPersona);
            if (personafound == null)
                return;
            _appContext.Personas.Remove(personafound);
            _appContext.SaveChanges();
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas;
        }
        
        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
            return _appContext.Personas.FirstOrDefault(p => p.ID == idPersona);
        }
        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personafound = _appContext.Personas.FirstOrDefault(p => p.ID == persona.ID);
            if (personafound != null)
            {
                personafound.Nombre = persona.Nombre;
                personafound.Documento = persona.Documento;
                personafound.NumeroTelefono = persona.NumeroTelefono;

                _appContext.SaveChanges();
            }

            return personafound;
        }

    }
}
