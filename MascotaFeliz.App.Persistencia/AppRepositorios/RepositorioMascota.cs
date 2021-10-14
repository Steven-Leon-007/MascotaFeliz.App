using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using static MascotaFeliz.App.Persistencia.RepositorioPropietario;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        private readonly AppContext _appContext;

        public RepositorioMascota(AppContext appContext)
        {
            _appContext=appContext;
        }
        Mascota IRepositorioMascota.AddMascota(Mascota nuevaMascota)
        {
            var mascotaAdicionado=_appContext.Mascotas.Add(nuevaMascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }

        void IRepositorioMascota.DeleteMascota(int idMascota)
        {
            var mascotaEncontrado=_appContext.Mascotas.FirstOrDefault(p =>p.Id==idMascota);
            if(mascotaEncontrado==null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m =>m.Id==idMascota);

        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascotaActualizado)
        {
            var mascotaEncontrado=_appContext.Mascotas.FirstOrDefault(m =>m.Id== mascotaActualizado.Id);
            if (mascotaEncontrado!=null)
            {
                mascotaEncontrado.NombreMascota=mascotaActualizado.NombreMascota;
                mascotaEncontrado.Raza=mascotaActualizado.Raza;
                mascotaEncontrado.TipoAnimal=mascotaActualizado.TipoAnimal;
                mascotaEncontrado.Propietario=mascotaActualizado.Propietario;

                _appContext.SaveChanges();
                
            }
            return mascotaEncontrado;
        }

    }
    
}