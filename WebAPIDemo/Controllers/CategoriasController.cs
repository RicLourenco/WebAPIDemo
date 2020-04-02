using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// Controlador das categorias
    /// </summary>
    public class CategoriasController : ApiController
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: api/Categorias
        /// <summary>
        /// Lista de todas as categorias na tabela "categorias"
        /// </summary>
        /// <returns>Lista com todas as categorias</returns>
        public List<categoria> Get()
        {
            var lista = from categoria in dc.categorias select categoria;
            return lista.ToList();
        }

        // GET: api/Categorias/5
        /// <summary>
        /// Categoria consoante a sigla indicada da tabela "categorias"
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns>Categoria consoante a sigla indicada</returns>
        [Route("api/categorias/{sigla}")]
        public IHttpActionResult Get(string sigla)
        {
            var categoria = dc.categorias.SingleOrDefault(x => x.sigla == sigla);

            if(categoria != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, categoria));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categoria não existe"));
        }

        // POST: api/Categorias
        /// <summary>
        /// Insere uma nova categoria na tabela "categorias"
        /// </summary>
        /// <param name="novaCategoria"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]categoria novaCategoria)
        {
            categoria categoria = dc.categorias.FirstOrDefault(x => x.sigla == novaCategoria.sigla);

            if(categoria != null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Já existe uma categoria com essa sigla"));
            }

            dc.categorias.InsertOnSubmit(novaCategoria);

            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, e));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
        }

        // PUT: api/Categorias/5
        /// <summary>
        /// Atualiza uma categoria da tabela "categorias"
        /// </summary>
        /// <param name="novaCategoria"></param>
        /// <returns>Mensagem de resposta se sucedeu no insert ou não</returns>
        public IHttpActionResult Put([FromBody]categoria novaCategoria)
        {
            categoria categoria = dc.categorias.FirstOrDefault(x=>x.sigla == novaCategoria.sigla);

            if(categoria == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe uma categoria com essa sigla"));
            }

            categoria.sigla = novaCategoria.sigla;
            categoria.categoria1 = novaCategoria.categoria1;

            try
            {
                dc.SubmitChanges();
            }
            catch(Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, e));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
        }

        // DELETE: api/Categorias/5
        /// <summary>
        /// Apaga a categoria com a sigla indicada da tabela "categorias"
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        [Route("api/categorias/{sigla}")]
        public IHttpActionResult Delete(string sigla)
        {
            categoria categoria = dc.categorias.FirstOrDefault(x => x.sigla == sigla);

            filme filme = dc.filmes.FirstOrDefault(x => x.categoria == sigla);

            if(filme != null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Essa categoria tem um filme associado"));
            }

            if(categoria != null)
            {
                dc.categorias.DeleteOnSubmit(categoria);

                try
                {
                    dc.SubmitChanges();
                }
                catch(Exception e)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, e));
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe uma categoria com essa sigla"));
        }
    }
}
