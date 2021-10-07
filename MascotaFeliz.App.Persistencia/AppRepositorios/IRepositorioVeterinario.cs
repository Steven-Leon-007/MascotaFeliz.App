using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        //Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario AddVeterinario(Veterinario nuevoVeterinario);

        Veterinario UpdateVeterinario(Veterinario veterinarioActualizado);
        //Veterinario UpdateVeterinario(Veterinario veterinario, int idVeterinario_original);
        void DeleteVeterinario(int IdVeterinario);
        Veterinario GetVeterinario(int IdVeterinario);
        Veterinario GetVeterinarioPorId(int veterinarioId);
    }
}