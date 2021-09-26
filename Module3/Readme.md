<h1>Interacting between Console and database</h1>

<h2>2. Creating the interface</h2>

The first step to achieving the connection between the database and console is creating the interfaces of each entity, the following steps are implemented for 1 entity (which will be Persona), but the steps are the same to all entities of the project.

<h2>1. Creating the interface</h2>
In order to have a clean project, inside the *AppRepositorios* we are going to create a interface called `IRepositorioPersona` which will be a class interface and another class what will implement that interface and was called `RepositorioPersona`

The interface, was written in the following fashion

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
<h2>Implementing the class inherited from interface</h2>

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
Although the Dominio and Persistencia were declared at the top of the code, is needed to add a reference pointing to **Dominio** and **Persistencia**, this is done by typing the two followings commands

`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

**Note:** The 2 previous commands must be run in the Console folder

<h2>Breaking down the Code</h2>

The following lines will explain how each chunk of the Repositorio works

<h3>Instantiating AppContext </h3>

```c#
    private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();
```
The above line create a instance of AppContext, and the modifier `readonly` indicates that the instance is immutable

The newly created instance was called `_appContext`, the AppContext class as we can recall was one implemented in module 2 and it inherited from DbContext and is needed to perform the migration which is the way of pass from classes to database schema automatically

To remind AppContext class we will rewrite them

```c#
using Microsoft.EntityFrameworkCore;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
   public class AppContext : DbContext
   {
       public DbSet<Persona> Personas {get; set;}

       protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TorneoFutbolData");
           }
                            
        }
    }
} 
```
The AppContext which inherited from DbContext allow to use DbSet, to dip into how DbSet and Dbcontex Work referring to the following link 

[Working with DbContext](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext)


<h3>Creating "Add new person" to database </h3>

```c#

    Persona IRepositorioPersona.AddPersona(Persona persona)
    {
        var personaAdded = _appContext.Personas.Add(persona);
        _appContext.SaveChanges();
        return personaAdded.Entity; 
    }

```
AddPersona is a method which allow us to put personas into the database, this method is declared as a Persona type, which is a class already created, to refresh our memory we will rewrite such class 

```c#

public class Persona
    {
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Documento { get; set; }
    public string NumeroTelefono { get; set; }
    } 

```

The IRepositorioPersona.AddPersona is a class which take as input a Persona and also return a Persona type, inside the class is created a variable named personaAdded 

<h3>Deleting a Person from the Database</h3>

The function which implement the code to delete a person from the database is shown as follows

```c#

RepositorioPersona.DeletePersona(int idPersona)
{
    var personafound = _appContext.Personas.FirstOrDefault(p => p.ID == idPersona);
    if (personafound == null)
        return;
    _appContext.Personas.Remove(personafound);
    _appContext.SaveChanges();
}
```
The above class also create a instance from AppContext and look for a person, it access to person class which is stored in a database through the ID setting as a parameter of the constructor, if the ID is found then such number is assign ti a variable p, and then the Method **FirstOrDefault** will look for the ID what stand that ID and with the method Remove perform the operation of deleting that persona.


To see what does the [=>](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator) click on it

<h3>querying for a person</h3>

This operation works in similar way as Delete, its mean in the class must be putting the ID and through FirstOrDefault method that person will be searched, but in this case we are interested just in show the person who has that ID.

The snipped that person the query is the following

```c#
 Persona IRepositorioPersona.GetPersona(int idPersona)
     {
     return _appContext.Personas.FirstOrDefault(p => p.ID == idPersona);
     }

```
<h3>Updating a person</h3>

To complete the crud just remain the update function this is done first of all by searching the person by ID, and if them was found the person will be update, the code is as follow

```c#
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
```

