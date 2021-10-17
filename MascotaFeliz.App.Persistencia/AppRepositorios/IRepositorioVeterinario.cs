using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario AddVeterinario(Veterinario nuevoVeterinario);
        Veterinario UpdateVeterinario(Veterinario veterinarioActualizado);
        void DeleteVeterinario(int idVeterinario);    
        Veterinario GetVeterinario(int idVeterinario);
        IEnumerable<Veterinario> SearchVeterinarios(string nombre);
        IEnumerable<Veterinario> SearchVeterinarioxId(string iden);
    }

}