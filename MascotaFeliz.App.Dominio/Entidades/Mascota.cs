using System;

namespace MascotaFeliz.App.Dominio
{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>  
    public class Mascota
    {
        ///Hola:) 
        public int  Id { get; set;}
        public string NombreMascota {get; set;}
        public string Raza {get;set;}
        public Tipo TipoAnimal {get;set;}
        public Propietario Propietario {get;set;}
    }
} 