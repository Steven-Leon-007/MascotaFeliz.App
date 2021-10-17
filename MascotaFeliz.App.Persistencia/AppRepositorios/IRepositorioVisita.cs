using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisita
    {
        IEnumerable<Visita> GetAllVisitas();
        Visita AddVisita(Visita nuevaVisita);
        Visita UpdateVisita(Visita visitaActualizado);
        void DeleteVisita(int idVisita);    
        Visita GetVisita(int idVisita);
       
    }

}