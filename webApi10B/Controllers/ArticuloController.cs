using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApi10B.Models;
using System.Net.Http;

namespace webApi10B.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public HttpResponseMessage Get()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listar();
               
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/Articulo/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = negocio.listar().FirstOrDefault(a => a.Id == id);

            
                if (articulo == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el artículo con el ID " + id);
                }

                return Request.CreateResponse(HttpStatusCode.OK, articulo);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST: api/Articulo
        public HttpResponseMessage Post([FromBody] ArticuloDTO nuevoDto)
        {
            try
            {
                if (nuevoDto == null || string.IsNullOrEmpty(nuevoDto.Codigo) || string.IsNullOrEmpty(nuevoDto.Nombre))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "El código y el nombre son campos obligatorios.");
                }

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                if (!marcaNegocio.listar().Any(m => m.Id == nuevoDto.IdMarca))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "La marca con el ID especificado no existe.");
                }

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                if (!categoriaNegocio.listar().Any(c => c.Id == nuevoDto.IdCategoria))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "La categoría con el ID especificado no existe.");
                }

                Articulo nuevo = new Articulo
                {
                    Codigo = nuevoDto.Codigo,
                    Nombre = nuevoDto.Nombre,
                    Descripcion = nuevoDto.Descripcion,
                    IdMarca = nuevoDto.IdMarca,
                    IdCategoria = nuevoDto.IdCategoria,
                    Precio = nuevoDto.Precio,
                    Imagenes = nuevoDto.Imagenes.Select(i => new Imagen { ImagenUrl = i.ImagenUrl }).ToList()
                };

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregar(nuevo);

                return Request.CreateResponse(HttpStatusCode.Created, "Artículo agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Articulo/5
        public HttpResponseMessage Put(int id, [FromBody] ArticuloDTO dto)
        {
            try
            {
                if (dto == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Body vacío.");

                var negocio = new ArticuloNegocio();
                if (!negocio.listar().Any(a => a.Id == id))
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El artículo a modificar no existe.");

                var marcaNegocio = new MarcaNegocio();
                if (!marcaNegocio.listar().Any(m => m.Id == dto.IdMarca))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "La marca especificada no existe.");

                var categoriaNegocio = new CategoriaNegocio();
                if (!categoriaNegocio.listar().Any(c => c.Id == dto.IdCategoria))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "La categoría especificada no existe.");


                var articulo = new Articulo
                {
                    Id = id,
                    Codigo = dto.Codigo,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    IdMarca = dto.IdMarca,
                    IdCategoria = dto.IdCategoria,
                    Precio = dto.Precio,
                    Imagenes = dto.Imagenes?.Select(i => new Imagen { ImagenUrl = i.ImagenUrl }).ToList()
                                  ?? new List<Imagen>()
                };

                negocio.modificar(articulo);

                return Request.CreateResponse(HttpStatusCode.OK, "Artículo modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Articulo/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                
                if (!negocio.listar().Any(a => a.Id == id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El artículo que intenta eliminar no existe.");
                }

                negocio.eliminar(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Artículo eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
