using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        Mascota AddMascota(Mascota nuevaMascota);
        Mascota UpdateMascota(Mascota mascotaActualizado);
        void DeleteMascota(int idMascota);    
        Mascota GetMascota(int idMascota);

    }

}