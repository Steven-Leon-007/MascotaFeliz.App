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
    public class DetailsPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioMascota repositorioMascota;
        public Propietario Propietario { get; set; }

        public DetailsPropietarioModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int propietarioId)
        {

            Propietario = repositorioPropietario.GetPropietario(propietarioId);
            if (Propietario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
        public void OnPost(int idmascota,int idpropietario)
        {
            Console.WriteLine(idmascota+idpropietario);
            repositorioMascota.DeleteMascota(idmascota);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>La mascota seleccionada se eliminó.</span>");
            Propietario = repositorioPropietario.GetPropietario(idpropietario);            
        }
    }

}