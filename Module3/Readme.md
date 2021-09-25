<h1>Interacting between Console and database</h1>

<h2>2. Creating the interface</h2>

The first step to achieving the connection between the database and console is creating the interfaces of each entity, the following steps are implemented for 1 entity (which will be Persona), but the steps are the same to all entities of the project.

<h2>1. Creating the interface</h2>
In order to have a clean project, inside the *AppRepositorios* we going to create a interface called `IRepositorioPersona` which will be a class interface and a class what will implement it called `RepositorioPersona`

The interface, is writing in the following fashion

```c#
using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioPersona
        {
            IEnumerable<Pesrona> GetAllPersonas();
            Persona AddPersona(Persona persona);
            Persona UpdatePersona(Persona persona);
            void DeletePersona(int idPersona);
            Persona GetPersona(int idPersona);
        }

}
```

Note: IEnumerable is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
<h2>Implementing the interface inherited from interface</h2>

As in the previous step we implemented the interface, here the interface will be inherited by a class named RepositorioPersona,the class has the following way
```c#

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
```
Although the Dominio and Persistencia are declared at the top of the code, is needed add a reference pointing to **Dominio** and **Persistencia**, this is done by typing the two followings commands 
`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

**Note:** The 2 following commands must be run in the Console folder


