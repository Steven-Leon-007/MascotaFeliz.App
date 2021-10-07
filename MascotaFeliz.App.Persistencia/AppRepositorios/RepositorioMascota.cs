using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using static MascotaFeliz.App.Persistencia.RepositorioPropietario;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        static public List<Mascota> mascotas;
        private readonly AppContext _appContext;

        public RepositorioMascota(AppContext appContext)
        {
            _appContext=appContext;
        }

        public RepositorioMascota()
        {
            mascotas = new List<Mascota>()
            {
                new Mascota{Id=1,NombreMascota="Pepito",Raza="Bull Dog",TipoAnimal=Tipo.Canino,Propietario=RepositorioPropietario.propietarios[0]},
                new Mascota{Id=2,NombreMascota="Luna",Raza="Criollo",TipoAnimal=Tipo.Felino,Propietario=RepositorioPropietario.propietarios[1]},
                new Mascota{Id=3,NombreMascota="Tom",Raza="Persa",TipoAnimal=Tipo.Felino,Propietario=RepositorioPropietario.propietarios[2]},
                new Mascota{Id=4,NombreMascota="Pelos",Raza="Golden Retriever",TipoAnimal=Tipo.Canino,Propietario=RepositorioPropietario.propietarios[3]}
            };
        }

        public Mascota GetMascotaPorId(int mascotaId)
        {
            return mascotas.SingleOrDefault(m => m.Id ==mascotaId);
        }
        /*Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionado=_appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }*/
        public Mascota AddMascota(Mascota nuevaMascota)
        {
            nuevaMascota.Id=mascotas.Max(r => r.Id)+1;
            mascotas.Add(nuevaMascota);
            return nuevaMascota;
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
            //return _appContext.Mascotas;
            return mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int IdMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota);

        }

        /*Mascota IRepositorioMascota.UpdateMascota(Mascota mascota, int idMascota_original)
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

        }*/

        public Mascota UpdateMascota(Mascota mascotaActualizado)
        {
            var mascota = mascotas.SingleOrDefault(r => r.Id == mascotaActualizado.Id);
            if (mascota!=null)
            {
                mascota.NombreMascota=mascotaActualizado.NombreMascota;
                mascota.Raza=mascotaActualizado.Raza;
                mascota.TipoAnimal=mascotaActualizado.TipoAnimal;
                mascota.Propietario=mascotaActualizado.Propietario;
            }
            return mascota;
        }
    }
}