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

        private readonly IRepositorioVisita repositorioVisita;

        public IEnumerable<Visita> Visitas {get;set;}
        
        public VisitasRegModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = repositorioVisita;
        }


        public void OnGet()
        {
             Visitas = repositorioVisita.GetAllVisitas();   
        }
    }
}
