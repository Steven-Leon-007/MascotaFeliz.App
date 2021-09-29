using System;

namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {
        public Visita(int id, DateTime fecha)
        {
            Id = id;
            DateTime Fecha = new DateTime(2021,10,21);
        }

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