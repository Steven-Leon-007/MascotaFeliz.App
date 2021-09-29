using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        private readonly AppContext _appContext;

        public RepositorioMascota(AppContext appContext)
        {
            _appContext=appContext;
        }
        Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionado=_appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }

        void IRepositorioMascota.DeleteMascota(int IdMascota)
        {
            var mascotaEncontrado=_appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota);
            if(mascotaEncontrado==null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int IdMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota);

        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota, int idMascota_original)
        {
            var mascotaEncontrado=_appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota_original);
            if (mascotaEncontrado==null)
            {
                mascotaEncontrado.NombreMascota=mascota.NombreMascota;
                mascotaEncontrado.Raza=mascota.Raza;
                mascotaEncontrado.TipoAnimal=mascota.TipoAnimal;
                mascotaEncontrado.Propietario=mascota.Propietario;

                //mascotaEncontrado.TarjetaProfesional=mascota.TarjetaProfesional;

                _appContext.SaveChanges();
                
            }
            return mascotaEncontrado;
        }
    }
}