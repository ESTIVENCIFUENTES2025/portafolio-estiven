using Portafolio.Models;

namespace Portafolio.Controllers.Servicios
{
    public interface IRepositorioProyectos
{
    List<ProyectoDTO> ObtenerProyectos();
}

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>() {
           new ProyectoDTO
            {
                Titulo = "Coopebombas",
                Descripcion = "Desarrollo  Web,Asp.net",
                Link = "https://coopebombas.com",
                ImagenURl = "/imagenes/coopebombas.PNG"

            },

             new ProyectoDTO
             {
                Titulo = "Pacientes Veterinaria",
                Descripcion = "Desarrollo  Web,React",
                Link = "https://verdant-dolphin-c6740c.netlify.app/",
                ImagenURl = "/imagenes/Veterinaria.PNG"

             },


                new ProyectoDTO
                     {
                Titulo = "Cotizador de Prestamos",
                Descripcion = "Cotizador de Prestamos,React",
                Link = "https://glittering-taiyaki-73b1cf.netlify.app/",
                ImagenURl = "/imagenes/cotizadorprestamo.PNG"

                },


                new ProyectoDTO
                    {

                 Titulo = "Buscador de Autos",
                  Descripcion = "Buscador de Autos ,JavaScript",
                  Link = "https://voluble-beignet-3f32de.netlify.app/",
                  ImagenURl = "/imagenes/Buscador.PNG"

                 },

                       new ProyectoDTO
                    {

                 Titulo = "Tienda   de compras",
                  Descripcion = "Carro de compras ,JavaScript",
                  Link = "https://voluble-beignet-3f32de.netlify.app/",
                  ImagenURl = "/imagenes/carrito.PNG"

                 }




        };
        }
    }
}