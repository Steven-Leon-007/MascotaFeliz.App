using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DetailsVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario Veterinario { get; set; }

        public DetailsVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int veterinarioId)
        {

            Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);
            if (Veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }

}
