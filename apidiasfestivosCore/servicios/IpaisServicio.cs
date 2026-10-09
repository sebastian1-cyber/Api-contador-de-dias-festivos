using ApiDiasFestivosDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace apidiasfestivos.Core.servicios
{
    public interface IpaisServicio
    {
        Task<IEnumerable<Pais>> PaisObtenertodosPaises();

        Task<Pais> Obtener(int Id);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);

    }
}
