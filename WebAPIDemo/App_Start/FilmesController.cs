using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.App_Start
{
    /// <summary>
    /// Controlador dos filmes
    /// </summary>
    public class FilmesController : ApiController
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: api/Filmes
        /// <summary>
        /// Lista de todos os filmes na tabela "filmes"
        /// </summary>
        /// <returns></returns>
        public List<filme> Get()
        {
            var lista = from filme in dc.filmes orderby filme.titulo select filme;

            return lista.ToList();
        }

        // GET: api/Filmes/5
        /// <summary>
        /// Retorna um filme consoante o ID indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Filme</returns>
        public IHttpActionResult Get(int id)
        {
            var filme = dc.filmes.FirstOrDefault(x => x.id == id);
            if(filme != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, filme));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Filme não existe"));
        }

        // POST: api/Filmes
        /// <summary>
        /// Insere um filme novo na tabela "filmes"
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]filme novoFilme)
        {
            filme filme = dc.filmes.FirstOrDefault(x => x.id == novoFilme.id);

            if (filme != null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Já existe um filme com esse id"));
            }

            categoria categoria = dc.categorias.FirstOrDefault(x => x.sigla == novoFilme.categoria);

            if(categoria == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe uma categoria com essa sigla"));
            }

            dc.filmes.InsertOnSubmit(novoFilme);

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

        // PUT: api/Filmes/5
        /// <summary>
        /// Atualiza um filme consoante o ID indicado
        /// </summary>
        /// <param name="filmeAlterado"></param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody]filme filmeAlterado)
        {
            filme filme = dc.filmes.FirstOrDefault(x => x.id == filmeAlterado.id);

            if(filme == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe um filme com esse id"));
            }

            categoria categoria = dc.categorias.FirstOrDefault(x => x.sigla == filmeAlterado.categoria);

            if (categoria == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe uma categoria com essa sigla"));
            }

            filme.titulo = filmeAlterado.titulo;
            filme.categoria = filmeAlterado.categoria;

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

        // DELETE: api/Filmes/5
        /// <summary>
        /// Apaga um filme consoante o ID indicado da tabela "filmes"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            filme filme = dc.filmes.FirstOrDefault(x => x.id == id);

            if(filme != null)
            {
                dc.filmes.DeleteOnSubmit(filme);

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

            return ResponseMessage( Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não existe um filme com esse ID"));
        }
    }
}
