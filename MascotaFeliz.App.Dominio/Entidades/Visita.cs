using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {

        public int Id { get; set; }
        
        public Mascota Mascota {get; set;}
        public Veterinario Veterinario {get;set;}
        public DateTime Fecha {get; set;}
        [Required, StringLength(50)]
        public string Temperatura {get;set;}
        [Required, StringLength(50)]
        public string Peso {get;set;}
        [Required, StringLength(50)]
        public string FrecuenciaRespiratoria {get;set;}
        [Required, StringLength(50)]
        public string FrecuenciaCardiaca {get;set;}
        [Required, StringLength(50)]
        public string EstadoDeAnimo {get;set;}
        [Required, StringLength(100)]
        public string Recomendaciones {get;set;}


    }
}