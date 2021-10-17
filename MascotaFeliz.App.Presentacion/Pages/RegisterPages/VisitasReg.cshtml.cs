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
    public class VisitasRegModel : PageModel
    {
        public string bActual{get; set;}
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios { get; set; }

        private readonly IRepositorioVisita repositorioVisita;

        public IEnumerable<Visita> Visitas { get; set; }

        public VisitasRegModel()
        {
            this.repositorioVisita = new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }


        public void OnGet(string nombre)
        {
            Veterinarios = repositorioVeterinario.GetAllVeterinarios(); 
        }
        public void OnPost(int idvisita)
        {
            repositorioVisita.DeleteVisita(idvisita);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>La mascota seleccionada se eliminó.</span>");
            Veterinarios = repositorioVeterinario.GetAllVeterinarios();
        }
    }

}
