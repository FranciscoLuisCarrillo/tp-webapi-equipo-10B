using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApi10B.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public IEnumerable<Articulo> Get()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listar();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }

        // GET: api/Articulo/5
        public Articulo Get(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> articulos = negocio.listar();
            return articulos.Find(articulo => articulo.Id == id);
        }

        // POST: api/Articulo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();        
                Articulo articuloExistente = negocio.listar().FirstOrDefault(a => a.Id == id);              
                if (articuloExistente == null)
                {
                    return NotFound();
                }        
                negocio.eliminar(id);               
                return Ok();
            }
            catch (Exception ex)
            {               
                return InternalServerError(ex);
            }
        }
    }
}
