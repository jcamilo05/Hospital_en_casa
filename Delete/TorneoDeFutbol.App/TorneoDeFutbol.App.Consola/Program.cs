using System;
using TorneoDeFutbol.App.Dominio;
using TorneoDeFutbol.App.Persistencia;

namespace TorneoDeFutbol.App.Consola
{
    class Program
    {
        //arbitro
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro(new Persistencia.AppContext());
        //municipio
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        //jugador
        private static IRepositorioJugador _repoJugador = new RepositorioJugador(new Persistencia.AppContext());
        //Director t
        private static IRepositorioDT _repoDT = new RepositorioDT(new Persistencia.AppContext());
        //estadio
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext()); 
        
        //equipo
        //private static IRepositorioEquipo _repoEquipo = new IRepositorioEquipo(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola Torneo Departamental!");
            //AddArbitro();
            //
            //UpdateArbitro();
            //BuscarArbitro(1);
            //AddMunicipio();
            //BuscarMunicipio(1);
            //UpdateMunicipio();
            //Console.WriteLine("---------------");
            //BuscarMunicipio(2);
            //DeleteMunicipio(2);
            //AddJugador();
            
            //UpdateJugador();
            //BuscarJugador(2);
            //AddDT();
            //BuscarDT(2);
            //EliminarDT(9);
            //AddEstadio();

        }
        /*
        #===========================================#
        #      Inicio Metodos Crud Arbitros         #
        #===========================================#
        */  
        private static void AddArbitro()
        {
            var arbitro = new Arbitro
            {
                Nombre  = "Juan Giraldo",
                Documento = "512345678",
                NumeroTelefono = "3145482414",
                Colegio = "El rosario",
            };

            _repoArbitro.AddArbitro(arbitro);
        }

        private static void BuscarArbitro (int idArbitro)
        {
            var arbitro = _repoArbitro.GetArbitro(idArbitro);
            Console.WriteLine(arbitro.Nombre+" " +arbitro.Documento);
        }
        
        
        private static void EliminarArbitro(int idArbitro)
        {
            var arbitro = _repoArbitro.GetArbitro(idArbitro);
            _repoArbitro.DeleteArbitro(arbitro.Id);
        }
        
        private static void UpdateArbitro()
        {
            var arbitro = new Arbitro
            {
                Id = 2,
                Nombre  = "Juanito Paez",
                Documento = "123321",
                NumeroTelefono = "1231232",
                Colegio = "El colegio",
            };
            _repoArbitro.UpdateArbitro(arbitro);
        }
        /*
        #===========================================#
        #      Inicio Metodos Crud Municipios       #
        #===========================================#
        */  
        private static void AddMunicipio()
        {
            var municipio = new Municipio
            {
                Nombre = "Bogota",
                Departamento = "Cundinamarca",
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void UpdateMunicipio()
        {
            var municipio = new Municipio
            {
                Id = 1,
                Nombre = "Puerto Asis",
                Departamento = "Putumayo",
            };
            _repoMunicipio.UpdateMunicipio(municipio);
        }
        private static void BuscarMunicipio (int idMunicipio)
        {
            var municipio = _repoMunicipio.GetMunicipio(idMunicipio);
            Console.WriteLine(municipio.Nombre+", " +municipio.Departamento);
        }
        private static void DeleteMunicipio(int idMunicipio)
        {
            _repoMunicipio.DeleteMunicipio(idMunicipio);
            Console.WriteLine("se eliminó correctamente");
        }


        /*
        #===========================================#
        #      Inicio Metodos Crud Jugador          #
        #===========================================#
        */ 
        private static void AddJugador()
        {
            var jugador = new Jugador
            {
                Id = 1,
                //var pos = new Posicion();
                Nombre  = "Pedrito perez",
                Documento = "123321",
                NumeroTelefono = "1231232",
                Numero = "1",
                Posicion = Posicion.Volante,
            };
            _repoJugador.AddJugador(jugador);
        }
        private static void UpdateJugador()
        {
            var jugador = new Jugador
            {
                Id = 1,
                Nombre  = "Leonel nessi",
                Documento = "123321",
                NumeroTelefono = "1231232",
                Numero = "11",
                Posicion = Posicion.Delantero,
            };
            _repoJugador.UpdateJugador(jugador);
        }        
        private static void BuscarJugador (int idJugador)
        {
            var jugador = _repoJugador.GetJugador(idJugador);
            Console.WriteLine(jugador.Nombre+", "+jugador.Posicion);
        }
        private static void EliminarJugador(int idJugador)
        {
            var jugador = _repoJugador.GetJugador(idJugador);
            _repoJugador.DeleteJugador(jugador.Id);
        }
        /*
        #===========================================#
        #          Inicio Metodos Crud DT           #
        #===========================================#
        */ 

        private static void AddDT()
        {
            var dt = new DT
            {
                Nombre  = "Tatiaddna Giraldo",
                Documento = "512345678",
                NumeroTelefono = "3145482414",
            };

            _repoDT.AddDT(dt);
        }

        private static void BuscarDT (int idDT)
        {
            var dt = _repoDT.GetDT(idDT);
            Console.WriteLine(dt.Nombre);
        }
        
        
        private static void EliminarDT(int idDT)
        {
            var dt = _repoDT.GetDT(idDT);
            _repoDT.DeleteDT(dt.Id);
        }
        
        

        private static void UpdateDT()
        {
            var dt = new DT
            {
                Id = 1,
                Nombre  = "Juanito Paez",
                Documento = "123321",
                NumeroTelefono = "1231232",
            };
            _repoDT.UpdateDT(dt);
        }
        /*
        #===========================================#
        #      Inicio Metodos Crud Estadio          #
        #===========================================#
        */ 
        private static void AddEstadio()
        {
            var estadio = new Estadio
            {
                
                Nombre = "Palogrande",
                Direccion = "unknown",
            };
            _repoEstadio.AddEstadio(estadio);
        }

        private static void UpdateEstadio()
        {
            var estadio = new Estadio
            {
                Id = 1,
                Nombre = "Atanasio",
                Direccion = "Medellin",
            };
            _repoEstadio.UpdateEstadio(estadio);
        }
        private static void BuscarEstadio (int idEstadio)
        {
            var estadio = _repoEstadio.GetEstadio(idEstadio);
            Console.WriteLine(estadio.Nombre+", " +estadio.Direccion);
        }
        private static void DeleteEstadio(int idEstadio)
        {
            _repoEstadio.DeleteEstadio(idEstadio);
            Console.WriteLine("se eliminó correctamente");
        }
    }
}
