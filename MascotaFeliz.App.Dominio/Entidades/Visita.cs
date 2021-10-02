using System;

namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {

        public int Id { get; set; }
        public Mascota Mascota {get; set;}
        public Veterinario Veterinario {get;set;}
        public DateTime Fecha {get; set;}
        public float Temperatura {get;set;}
        public float Peso {get;set;}
        public int FrecuenciaRespiratoria {get;set;}
        public int FrecuenciaCardiaca {get;set;}
        public string EstadoDeAnimo {get;set;}
        public string Recomendaciones {get;set;}


    }
}