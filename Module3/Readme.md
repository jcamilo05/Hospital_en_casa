<h1>Interacting between Console and database</h1>

<h2>2. Creating the interface</h2>

The first step to achieving the connection between the database and console is creating the interfaces of each entity, the following steps are implemented for 1 entity (which will be Persona), but the steps are the same to all entities of the project.

<h2>1. Creating the interface</h2>
In order to have a clean project, inside the *AppRepositorios* we must creating a interface called `IRepositorioPersona` which will be a class interface and a class whom implement it called `RepositorioPersona`

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
<h2>Implementing the interface with a normal class</h2>

As in the previous step we implementing the interface, here the interface will be inherited by a class named RepositorioPersona,the class has the following way

