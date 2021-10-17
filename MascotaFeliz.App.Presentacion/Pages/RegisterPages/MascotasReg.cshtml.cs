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
    public class MascotasRegModel : PageModel
    {
        public string bActual{get; set;}
        public int tActual{get; set;}
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario; 
        public IEnumerable<Propietario> Propietarios{get;set;}
        public IEnumerable<Mascota> Mascotas{get;set;} 
        
        public MascotasRegModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public void OnGet(int? tipo, string nombre)
        {
            Propietarios = repositorioPropietario.GetAllPropietarios();
        }
        public void OnPost(int idmascota)
            {
            repositorioMascota.DeleteMascota(idmascota);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>La mascota seleccionada se eliminó.</span>");
            Propietarios=repositorioPropietario.GetAllPropietarios();            
            }
    }

}
