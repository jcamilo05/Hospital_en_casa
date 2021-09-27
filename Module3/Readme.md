<h1>Interacting between Console and database</h1>

<h2>1. Create the interface</h2>

The first step to achieve the connection between the database and console is the creation of the interface for each entity, the following steps was implemented for 1 entity (which will be Jugador), but the steps are the same to all entities of this project.

In order to have a clean project, inside the *AppRepositorios* we are going to create a interface called `IRepositorioJugador` which will be a class interface, and another class what we will implement is interface and is called `RepositorioJugador`

The interface, was written in the following fashion

```c#
using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioJugador
        {
            Jugador AddJugador(Jugador jugador);
            Jugador UpdateJugador(Jugador jugador);
            void DeleteJugador(int idJugador);
            Jugador GetJugador(int idJugador);
        }

}
```

**Note:** IEnumerable is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement

<h2>2.Implement the class inherited from interface</h2>

Since in the previous step we implemented the interface, here the interface will be inherited by a class named RepositorioJugador,the class was coded as follows. 

```c#

using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly Persistencia.AppContext _appContext = new Persistencia.AppContext();
        Jugador IRepositorioJugador.AddJugador(Jugador jugador)
        {
            var jugadorAdded = _appContext.Jugadors.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdded.Entity; 
        }

        void IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorfound = _appContext.Jugadors.FirstOrDefault(p => p.ID == idJugador);
            if (jugadorfound == null)
                return;
            _appContext.Jugadors.Remove(jugadorfound);
            _appContext.SaveChanges();
        }

        IEnumerable<Jugador> IRepositorioJugador.GetAllJugadors()
        {
            return _appContext.Jugadors;
        }
                
        Jugador IRepositorioJugador.GetJugador(int idJugador)
        {
            return _appContext.Jugadors.FirstOrDefault(p => p.ID == idJugador);
        }
        Jugador IRepositorioJugador.UpdateJugador(Jugador jugador)
        {
            var jugadorfound = _appContext.Jugadors.FirstOrDefault(p => p.ID == jugador.ID);
            if (jugadorfound != null)
            {
                jugadorfound.Nombre = jugador.Nombre;
                jugadorfound.Documento = jugador.Documento;
                jugadorfound.NumeroTelefono = jugador.NumeroTelefono;

                _appContext.SaveChanges();
            }

            return jugadorfound;
        }

    }
}
```
Although the Dominio and Persistencia were declared at the top of the code, is needed to add a reference pointing to **Dominio** and **Persistencia**, this is done by typing the two followings commands

`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

`dotnet add reference ..\TorneoFutbol.App\TorneoFutbol.App.Dominio`

**Note:** The 2 previous commands must be run in the Console folder

<h2>3. Break down the Code</h2>

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
       public DbSet<Jugador> Jugadors {get; set;}

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
The AppContext which inherited from DbContext allow to use DbSet, to dip into how DbSet and Dbcontex Work referring to the followings links 

[1. Working with DbContext](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext)

[2. Entity Framework Core: DbContext](https://www.entityframeworktutorial.net/efcore/entity-framework-core-dbcontext.aspx)

<h3>Perform "Add new Jugador" to the database </h3>

```c#

    Jugador IRepositorioJugador.AddJugador(Jugador jugador)
    {
        var jugadorAdded = _appContext.Jugadors.Add(jugador);
        _appContext.SaveChanges();
        return jugadorAdded.Entity; 
    }

```
AddJugador is a method which allow us to put a jugador into the database, this method is declared as a Jugador type, which is a class already created. To refresh our memory we will rewrite them. 

```c#

public class Jugador
    {
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Documento { get; set; }
    public string NumeroTelefono { get; set; }
    public string Numero {get; set;{
    public string posicion {get;set;}
    } 

```

The **IRepositorioJugador.AddJugador** is a class which take as input a Jugador and also return a Jugador type, inside the class is created a variable named jugadorAdded 

<h3>Delete a Person from the Database</h3>

The function which implement the code to delete a person from the database is shown as follows

```c#

RepositorioJugador.DeleteJugador(int idJugador)
{
    var jugadorfound = _appContext.Jugadors.FirstOrDefault(p => p.ID == idJugador);
    if (jugadorfound == null)
        return;
    _appContext.Jugadors.Remove(jugadorfound);
    _appContext.SaveChanges();
}
```
The above class also create a instance from AppContext and look for a person, it access to person class which is stored in a database through the ID setting as a parameter of the constructor, if the ID is found then such number is assign ti a variable p, and then the Method **FirstOrDefault** will look for the ID what stand that ID and with the method Remove perform the operation of deleting that jugador.


To see what does the [=>](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator) click on it

<h3>query for a person</h3>

This operation works in similar way as Delete, its mean in the class must be putting the ID and through FirstOrDefault method that person will be searched, but in this case we are interested just in show the person who has that ID.

The snipped that person the query is the following

```c#
 Jugador IRepositorioJugador.GetJugador(int idJugador)
     {
     return _appContext.Jugadors.FirstOrDefault(p => p.ID == idJugador);
     }

```
<h3>Update a person</h3>

To complete the crud just remain the update function this is done first of all by searching the person by ID, and if them was found the person will be update, the code is as follow

```c#
Jugador IRepositorioJugador.UpdateJugador(Jugador jugador)
{
    var jugadorfound = _appContext.Jugadors.FirstOrDefault(p => p.ID == jugador.ID);
    if (jugadorfound != null)
    {
        jugadorfound.Nombre = jugador.Nombre;
        jugadorfound.Documento = jugador.Documento;
        jugadorfound.NumeroTelefono = jugador.NumeroTelefono;

        _appContext.SaveChanges();
    }

    return jugadorfound;
}
```

