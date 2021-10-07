using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {

        public int Id { get; set; }
        
        public Mascota Mascota {get; set;}
        public Veterinario Veterinario {get;set;}
        [Required, StringLength(50)]
        public DateTime Fecha {get; set;}
        [Required, StringLength(50)]
        public float Temperatura {get;set;}
        [Required, StringLength(50)]
        public float Peso {get;set;}
        [Required, StringLength(50)]
        public int FrecuenciaRespiratoria {get;set;}
        [Required, StringLength(50)]
        public int FrecuenciaCardiaca {get;set;}
        [Required, StringLength(50)]
        public string EstadoDeAnimo {get;set;}
        [Required, StringLength(100)]
        public string Recomendaciones {get;set;}


    }
}