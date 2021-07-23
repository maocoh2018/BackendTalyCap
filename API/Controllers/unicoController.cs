using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("Api/Bilioteca")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class unicoController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("GetLibros")]
        public IHttpActionResult GetUsuarios()
        {
            try
            {
                BibliotecaBLL libros = new BibliotecaBLL();
                return Content(HttpStatusCode.OK, libros.obtenerLibros());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Fallo en la conexion");
            }
        }

        [HttpGet]
        [Route("GetAutores")]
        public IHttpActionResult GetAutores()
        {
            try
            {
                BibliotecaBLL autores = new BibliotecaBLL();
                return Content(HttpStatusCode.OK, autores.obtenerAutores());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Fallo en la conexion");
            }
        }

        [HttpGet]
        [Route("GetAutor")]
        public IHttpActionResult GetAutor(string id)
        {
            try
            {
                BibliotecaBLL autores = new BibliotecaBLL();
                return Content(HttpStatusCode.OK, autores.obtenerAutor(id));
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Fallo en la conexion");
            }
        }



    }
}
