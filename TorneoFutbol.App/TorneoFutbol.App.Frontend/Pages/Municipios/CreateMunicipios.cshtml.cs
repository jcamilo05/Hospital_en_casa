using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;


namespace TorneoFutbol.App.Frontend.Pages.Municipios
{
    public class CreateMunicipiosModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Municipio municipio { get; set; }
        public CreateMunicipiosModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet()
        {
            municipio = new Municipio();
        }
            public IActionResult OnPost(Municipio municipio)
        {
            _repoMunicipio.AddMunicipio(municipio);
            return RedirectToPage("ListMunicipios");
        }
    }
}
