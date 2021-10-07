using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        //Mascota AddMascota(Mascota mascota);
        Mascota AddMascota(Mascota nuevaMascota);
        Mascota UpdateMascota(Mascota mascotaActualizado);
        //Mascota UpdateMascota(Mascota mascota, int idMascota_original);//modificada por mi para que funcionara
        void DeleteMascota(int idMascota);    
        Mascota GetMascota(int idMascota);
        //Medico AsignarMedico(int idPaciente, int idMedico); 
        Mascota GetMascotaPorId(int mascotaId);

    }
}