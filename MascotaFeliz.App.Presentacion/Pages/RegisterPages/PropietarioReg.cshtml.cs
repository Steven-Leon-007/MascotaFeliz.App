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
    public class PropietarioRegModel : PageModel
    {
        public string bActual{get; set;}
        private readonly IRepositorioPropietario repositorioPropietario;
        
        public IEnumerable<Propietario> Propietarios {get;set;}
        
        public PropietarioRegModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(string nombre)
        {
            if(String.IsNullOrEmpty(nombre))
            {
                bActual = "";
                Propietarios = repositorioPropietario.GetAllPropietarios();
            }
            else
            {
                bActual = nombre;
                Propietarios = repositorioPropietario.SearchPropietarios(nombre);
            }
        }
        public void OnPost(int idpropietario)
        {
            repositorioPropietario.DeletePropietario(idpropietario);
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span>Se eliminó el propietario seleccionado.</span>");
            Propietarios=repositorioPropietario.GetAllPropietarios();            
        }
    }

}
