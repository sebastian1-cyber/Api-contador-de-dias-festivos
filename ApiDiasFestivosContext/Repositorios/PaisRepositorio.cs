using Microsoft.EntityFrameworkCore;
using ApiDiasFestivosDominio;
using apidiasfestivos.Core.repositorios;
using ApiDiasFestivosInfraestructura.Persistencias;

namespace ApiDiasFestivosInfraestructura.Repositorios
{
    public class PaisRepositorio : IpaisRepositorio
    {
        private readonly ContadorDeDIasFestivosContext Contexto;
        public PaisRepositorio(ContadorDeDIasFestivosContext contexto)
        {
            this.Contexto = contexto;
        }
        public async Task<Pais> Obtener(int Id)
        {
            return await Contexto.Paises.FindAsync(Id);
        }

        public async Task<Pais> Agregar(Pais Pais)
        {
            Contexto.Paises.Add(Pais);
            await Contexto.SaveChangesAsync();
            return Contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<Pais> Modificar(Pais Pais)
        {
            var PaisExistente = await Contexto.Paises.FindAsync(Pais.Id);
            if (PaisExistente == null)
            {
                return null;
            }
            Contexto.Entry(PaisExistente).CurrentValues.SetValues(Pais);
            await Contexto.SaveChangesAsync();
            return Contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<bool> Eliminar(int Id)
        {
            var PaisExistente = await Contexto.Paises.FindAsync(Id);
            if (PaisExistente == null)
            {
                return false;
            }
            try
            {
                Contexto.Paises.Remove(PaisExistente);
                await Contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       public async Task<IEnumerable<Pais>> ObtenertodosPaises()
        {
            return await Contexto.Paises
                .OrderBy(pais => pais.Nombre)
                .ToListAsync();
        }
        public async Task<Pais> BuscarNombre( string Texto)     
        {
            return await Contexto.Paises
                .FirstOrDefaultAsync(pais => pais.Nombre == Texto);
        }

    
        
    }
}
