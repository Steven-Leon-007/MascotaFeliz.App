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
                mascotaEncontrado.Id =mascotaActualizado.Id;
                mascotaEncontrado.NombreMascota=mascotaActualizado.NombreMascota;
                mascotaEncontrado.Raza=mascotaActualizado.Raza;
                mascotaEncontrado.TipoAnimal=mascotaActualizado.TipoAnimal;

                _appContext.SaveChanges();
                
            }
            return mascotaEncontrado;
        }
        IEnumerable<Mascota> IRepositorioMascota.SearchMascotas(string nombre)
        {
            return _appContext.Mascotas
                        .Where(p => p.NombreMascota.Contains(nombre));
        }
        IEnumerable<Mascota> IRepositorioMascota.GetMascotaxTipo(int tipo)
        {
            return _appContext.Mascotas
                        .Where(p => p.TipoAnimal == (Tipo)tipo)
                        .ToList();
        }
        

    }
    
}