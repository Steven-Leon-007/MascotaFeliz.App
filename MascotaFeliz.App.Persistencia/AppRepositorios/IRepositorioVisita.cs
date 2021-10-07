using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisita
    {
        IEnumerable<Visita> GetAllVisitas();
        //Visita AddVisita(Visita visita);
        Visita AddVisita(Visita nuevaVisita);

        Visita UpdateVisita(Visita visitaActualizado);
        //Visita UpdateVisita(Visita visita, int idVisita_original);//modificada por mi para que funcionara
        void DeleteVisita(int idVisita);    
        Visita GetVisita(int idVisita);
        //Medico AsignarMedico(int idPaciente, int idMedico); 
        Visita GetVisitaPorId(int visitaId);
    }
}