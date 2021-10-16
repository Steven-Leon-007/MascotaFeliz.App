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
        public IEnumerable<Mascota> Mascotas{get;set;}
        
        public MascotasRegModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public void OnGet(int? tipo, string nombre)
        {
            if(String.IsNullOrEmpty(nombre))
            {
                bActual = "";
                Mascotas = repositorioMascota.GetAllMascotas();
            }
            else
            {
                bActual = nombre;
                Mascotas = repositorioMascota.SearchMascotas(nombre);
            }
            if(tipo.HasValue && tipo.Value != -1)
            {
                tActual = tipo.Value;
                Mascotas = repositorioMascota.GetMascotaxTipo(tipo.Value);
            }
            else
            {
                tActual = -1;
                Mascotas = repositorioMascota.GetAllMascotas();
            }
        }
    }

}
