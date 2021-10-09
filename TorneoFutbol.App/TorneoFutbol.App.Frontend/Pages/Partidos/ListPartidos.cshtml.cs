using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Partidos
{
    public class ListPartidosModel : PageModel
    {
    public Equipo equipo { get; set; }
    private readonly IRepositorioPartido _repoPartido;
    public IEnumerable<Partido> partidos { get; set; }
    public ListPartidosModel(IRepositorioPartido repoPartido, Equipo equipo)
    {
        equipo = new Equipo();
        _repoPartido = repoPartido;
    }
    public void OnGet()
    {

        partidos = _repoPartido.GetAllPartido();
    }
    }
}
