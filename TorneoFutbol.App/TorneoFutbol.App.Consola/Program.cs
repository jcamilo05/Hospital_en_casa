using System;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Consola
{
    class Program
    {
    private static IRepositorioPersona _repoPersona = new RepositorioPersona();
    static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
                AddPersona();
                Console.WriteLine("Persona Added");
           }

        private static void AddPersona()
        {
            var persona = new Persona();

                persona.Nombre = "Joe";
                persona.Documento  = "123 456";
                persona.NumeroTelefono = "555 6643";
            _repoPersona.AddPersona(persona);
        }
    }
}
