using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class EditVisitaModel : PageModel
    
    {
        [BindProperty]
        public Veterinario veterinario {get;set;}
        private readonly IRepositorioVisita repositorioVisita;
        public IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]
        public Visita visita { get; set; }
        public IEnumerable<Mascota> Mascotas{get;set;}
        public IRepositorioMascota repositorioMascota;

        public EditVisitaModel()
        {
            this.repositorioVisita = new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? visitaId, int? veterinarioId)
        {
            Mascotas = repositorioMascota.GetAllMascotas();
            if(visitaId.HasValue && veterinarioId.HasValue)
            {
            veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
            visita = repositorioVisita.GetVisita(visitaId.Value);
            }
            else
            {
                if (veterinarioId.HasValue)
                {
                    veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
                }
                else
                {
                    return RedirectToPage("./List");
                }
                visita = new Visita();
            }
            if (visita == null || veterinario == null)
            {
                return RedirectToPage("./List");
            }
            else
            ViewData["veterinario"] = veterinarioId.Value;
            return Page();
        }

        public IActionResult OnPost()
        {
            veterinario = repositorioVeterinario.GetVeterinario(int.Parse(Request.Form["veterinarioId"]));
            if (!ModelState.IsValid)
            {
                Console.WriteLine("no valido");
                return Page();
            }
            if (visita.Id > 0)
            {
                var visitae = repositorioVisita.UpdateVisita(visita);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span><strong>" + visitae.Mascota + "</strong> fue modificado correctamente.</span>");
            }
            else
            {
                if (veterinario == null)
                {
                    if (veterinario.Visitas != null)
                    {
                        veterinario.Visitas.Add(visita);
                        repositorioVeterinario.UpdateVeterinario(veterinario);
                        ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>" + visita.Mascota + "</strong> se agregó una nueva mascota para " + veterinario.Nombre + " " + veterinario.Apellidos + ".</span>");
                    }
                    else
                    {
                        veterinario.Visitas = new List<Visita>(){visita};
                        Console.WriteLine(JsonSerializer.Serialize(veterinario));
                        repositorioVeterinario.UpdateVeterinario(veterinario);
                        ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>" + visita.Mascota + "</strong> se agregó a la lista de mascotas de " + veterinario.Nombre + " " + veterinario.Apellidos + ".</span>");
                    }
                }
            }
            ViewData["veterinario"] = veterinario.Id;
            return Page();
        }
        
    }

}
