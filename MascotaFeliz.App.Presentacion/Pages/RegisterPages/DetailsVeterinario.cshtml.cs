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

        public DetailsVeterinarioModel(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinario = repositorioVeterinario;
        }

        public IActionResult OnGet(int veterinarioId)
        {

            Veterinario = repositorioVeterinario.GetVeterinarioPorId(veterinarioId);
            if (Veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}
