using System;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Consola
{
    class Program
    {
    private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio();
    static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
                AddEstadio();
                Console.WriteLine("Estadio Added");
           }

        private static void AddEstadio()
        {
            var estadio = new Estadio();

                estadio.Nombre = "Palogrande";
                estadio.Direccion  = "unknown";
            _repoEstadio.AddEstadio(estadio);
        }

        private static void DeleteEstadio(int 1);

    }
}
