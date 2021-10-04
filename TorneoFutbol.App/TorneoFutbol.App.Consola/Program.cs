using System;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Consola
{
    class Program
    {
        //arbitro
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro();
        //municipio
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        //jugador
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        //Director t
        private static IRepositorioDT _repoDT = new RepositorioDT();
        //estadio
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(); 
        //equipo
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        //partido
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        //novedad
        private static IRepositorioNovedad _repoNovedad = new RepositorioNovedad();

        static void Main(string[] args)
        {
            Console.WriteLine("Hola Torneo Departamental!");
            //AddArbitro();
            //AddArbitro();
            //UpdateArbitro();
            //BuscarArbitro(1);
            //BuscarArbitro(2);

            //AddMunicipio();
            //AddMunicipio();
            //UpdateMunicipio();
            //BuscarMunicipio(1);
            //BuscarMunicipio(2);

            //DeleteMunicipio(1);

            //AddJugador();
            //AddJugador();
            //UpdateJugador();
            //BuscarJugador(1);

            //AddDT();
            //BuscarDT(2);
            //EliminarDT(9);

            //AddEstadio();
            //AddEstadio();
            //UpdateEstadio();
            //BuscarEstadio(1);
            //BuscarEstadio(2);
            //DeleteEstadio(4);

            //AddEquipo();
            //AddEquipo();
            //UpdateEquipo();
            //BuscarEquipo(1);
            //BuscarEquipo(2);
            //linkDT(2,2);
            //linkJugador(1,1);
            //linkJugador(2,2);
            //linkEstadio(1,2);
            //linkEstadio(2,1);

            //AddPartido();
            //BuscarPartido(2);
            //linkLocal(2,1);
            //linkVisitante(2,2);
            //linkEstadioPartido(1,1);
            //linkArbitroPartido(1,1);
            
            //AddNovedad();
            //BuscarNovedad(2);
            //LinkNovedadPartido(2,1);
            //LinkNovedadJugador(2,2);
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
                Nombre  = "Andres Escobar",
                Documento = "43344325",
                NumeroTelefono = "5442266443",
                Colegio = "escuela de arbitros",
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
            _repoArbitro.DeleteArbitro(arbitro.ID);
        }
        
        private static void UpdateArbitro()
        {
            var arbitro = new Arbitro
            {
                ID = 1,
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
                //Estadio = new Estadio{Nombre="Palogrande", Direccion="Cra 5 89-554"},
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void UpdateMunicipio()
        {
            var municipio = new Municipio
            {
                ID = 1,
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
                
                //var pos = new Posicion();
                Nombre  = "Pedrito perez",
                Documento = "123321",
                NumeroTelefono = "1231232",
                Numero = "1",
                Posicion = "Volante",
            };
            _repoJugador.AddJugador(jugador);
        }
        private static void UpdateJugador()
        {
            var jugador = new Jugador
            {
                ID = 1,
                Nombre  = "Leonel messi",
                Documento = "123321",
                NumeroTelefono = "1231232",
                Numero = "11",
                Posicion = "Delantero",
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
            _repoJugador.DeleteJugador(jugador.ID);
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
                Nombre  = "Pekerman",
                Documento = "4566444",
                NumeroTelefono = "+21598995221",
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
            _repoDT.DeleteDT(dt.ID);
        }
        
        

        private static void UpdateDT()
        {
            var dt = new DT
            {
                ID = 1,
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
                ID = 1,
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
        /*
        #===========================================#
        #      Inicio Metodos Crud Equipo           #
        #===========================================#
        */ 
        private static void AddEquipo()
        {
            var equipo = new Equipo
            {
                Nombre = "asdasdasfas",
            };
            _repoEquipo.AddEquipo(equipo);
        }
        private static void BuscarEquipo (int idEquipo)
        {
            var equipo = _repoEquipo.GetEquipo(idEquipo);
            Console.WriteLine(equipo.Nombre);
        }
        private static void UpdateEquipo()
        {
            var equipo = new Equipo
            {
                ID = 1,
                Nombre = "river",
            };
            _repoEquipo.UpdateEquipo(equipo);
        }
        private static void AsignarJugador (int idEquipo, int idJugador)
        {
            //var equipo = _repoEquipo.(idEquipo);
            //Console.WriteLine(equipo.Nombre);
        }
        /*
        #===========================================#
        #         Inicio Metodos Partido            #
        #===========================================#
        */ 
        private static void AddPartido()
        {
            DateTime localDate = DateTime.Now;
            var partido = new Partido
            {
                FechaHora = localDate,
                //MarcadorInicialLocal = 0,
                //MarcadorInicialVisitante = 0,
            };
            _repoPartido.AddPartido(partido);
        }
        private static void BuscarPartido (int idPartido)
        {
            var partido = _repoPartido.GetPartido(idPartido);
            Console.WriteLine(partido.FechaHora);
            Console.WriteLine(partido.EquipoLocal);
            Console.WriteLine(partido.EquipoVisitante);
        }

        /*
        #===========================================#
        #         Inicio Metodos Novedad            #
        #===========================================#
        */     

        private static void AddNovedad()
        {
            DateTime localDate = DateTime.Now;
            var novedad = new Novedad
            {
                TipoNovedad = "falta",
                Time = localDate,
                //Jugador = Jugador,
                //Partido = Partido,
            };
            _repoNovedad.AddNovedad(novedad);
        }
        private static void BuscarNovedad (int idEstadio)
        {
            var novedad = _repoNovedad.GetNovedad(idEstadio);
            Console.WriteLine(novedad.Time+", " +novedad.Partido+", "+novedad.TipoNovedad);
        }

        /*
        #===========================================#
        #      Inicio Metodos Asignaciones          #
        #===========================================#
        */ 
        private static void linkDT (int idDT, int idEquipo)
        {
            var dt = _repoDT.LinkDT(idDT,idEquipo);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkJugador (int idJugador, int idEquipo)
        {
            var jugador = _repoJugador.LinkJugador(idJugador,idEquipo);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkEstadio (int idMunicipio, int idEstadio)
        {
            var municipio = _repoMunicipio.LinkEstadio(idMunicipio, idEstadio);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkLocal (int idPartido, int idEquipo)
        {
            var partido = _repoPartido.LinkLocal(idPartido, idEquipo);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkVisitante (int idPartido, int idEquipo)
        {
            var partido = _repoPartido.LinkVisitante(idPartido, idEquipo);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkEstadioPartido (int idPartido, int idEstadio)
        {
            var partido = _repoPartido.LinkEstadioPartido(idPartido, idEstadio);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void linkArbitroPartido (int idPartido, int idArbitro)
        {
            var partido = _repoPartido.LinkArbitroPartido(idPartido, idArbitro);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void LinkNovedadPartido (int idNovedad, int idPartido)
        {
            var novedad = _repoNovedad.LinkNovedadPartido(idNovedad,idPartido);
            //Console.WriteLine("se agregó correctamente");
        }
        private static void LinkNovedadJugador (int idNovedad, int idJugador)
        {
            var novedad = _repoNovedad.LinkNovedadJugador(idNovedad,idJugador);
            //Console.WriteLine("se agregó correctamente");
        }

        


        
        

    }
}
