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
        private readonly IRepositorioPropietario repositorioPropietario;
        
        public IEnumerable<Propietario> Propietarios {get;set;}
        
        public PropietarioRegModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            Propietarios = repositorioPropietario.GetAllPropietarios();
            
        }
    }

}
