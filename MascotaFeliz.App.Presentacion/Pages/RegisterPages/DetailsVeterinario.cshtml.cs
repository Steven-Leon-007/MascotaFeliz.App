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
        private readonly IRepositorioVisita repositorioVisita;
        public Veterinario Veterinario { get; set; }

        public DetailsVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioVisita = new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
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
        public void OnPost(int idvisita,int idveterinario)
        {
            repositorioVisita.DeleteVisita(idvisita);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>La mascota seleccionada se eliminó.</span>");
            Veterinario = repositorioVeterinario.GetVeterinario(idveterinario);           
        }
    }

}
