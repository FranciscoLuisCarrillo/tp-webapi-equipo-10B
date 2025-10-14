using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi10B.Models
{

    public class ImagenDTO
    {
        public string ImagenUrl { get; set; }
    }

    public class ArticuloDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }


        public List<ImagenDTO> Imagenes { get; set; } = new List<ImagenDTO>();
    }
}