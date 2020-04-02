using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    public class CategoriasController : ApiController
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: api/Categorias
        /// <summary>
        /// Lista de todas as categorias na tabela "categorias" da base de dados "DemoVideoClube"
        /// </summary>
        /// <returns>Lista com todas as categorias</returns>
        public List<categoria> Get()
        {
            var lista = from categoria in dc.categorias select categoria;
            return lista.ToList();
        }

        // GET: api/Categorias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categorias/5
        public void Delete(int id)
        {
        }
    }
}
