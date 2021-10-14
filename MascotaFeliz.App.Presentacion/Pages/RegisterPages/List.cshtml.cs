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
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios{get;set;}
        public ListModel()
        {
            this.repositorioVeterinario= new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            Veterinarios = repositorioVeterinario.GetAllVeterinarios();
        }
    }

}
