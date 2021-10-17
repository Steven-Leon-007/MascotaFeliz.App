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
    public class ListModel : PageModel
    {
        public string bActual{get; set;}
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios{get;set;}
        public ListModel()
        {
            this.repositorioVeterinario= new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public void OnGet(string nombre)
        {
            if(String.IsNullOrEmpty(nombre))
            {
                bActual = "";
                Veterinarios = repositorioVeterinario.GetAllVeterinarios();
            }
            else
            {
                bActual = nombre;
                Veterinarios = repositorioVeterinario.SearchVeterinarios(nombre);
            }
        }
        public void OnPost(int idveterinario)
        {
            repositorioVeterinario.DeleteVeterinario(idveterinario);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>Se eliminó el propietario seleccionado.</span>");
            Veterinarios=repositorioVeterinario.GetAllVeterinarios();            
        }
    }

}
