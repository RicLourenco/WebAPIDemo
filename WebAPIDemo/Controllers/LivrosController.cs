namespace WebAPIDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;

    /// <summary>
    /// Controlador dos livros
    /// </summary>
    public class LivrosController : ApiController
    {
        // GET: api/Livros
        /// <summary>
        /// Informação de todos os livros
        /// </summary>
        /// <returns>Lista de todos os livros</returns>
        public List<Livro> Get()
        {
            return Biblioteca.Livros;
        }

        // GET: api/Livros/5
        /// <summary>
        /// Informações do livro consoante o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta consoante se o livro foi encontrado pelo ID ou não</returns>
        public IHttpActionResult Get(int id)
        {
            Livro livro = Biblioteca.Livros.FirstOrDefault(x => x.ID == id);

            if(livro != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, livro));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Livro não localizado"));
        }

        // POST: api/Livros
        /// <summary>
        /// Adicionar um livro
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Resposta consoante se o livro foi encontrado pelo ID ou não</returns>
        public IHttpActionResult Post([FromBody]Livro obj)
        {
            Livro livro = Biblioteca.Livros.FirstOrDefault(x => x.ID == obj.ID);

            if(livro != null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Livro com ID já existente"));
            }

            Biblioteca.Livros.Add(obj);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
        }

        // PUT: api/Livros/5
        /// <summary>
        /// Alterar um livro
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Resposta consoante se o livro foi encontrado pelo ID ou não</returns>
        public IHttpActionResult Put([FromBody]Livro obj)
        {
            Livro livro = Biblioteca.Livros.FirstOrDefault(x => x.ID == obj.ID);

            if (livro != null)
            {
                livro.Titulo = obj.Titulo;
                livro.Autor = obj.Autor;
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Livro alterado"));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Livro não localizado"));
        }

        // DELETE: api/Livros/5
        /// <summary>
        /// Apaga um livro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Resposta consoante se o livro foi encontrado pelo ID ou não</returns>
        public IHttpActionResult Delete(int id)
        {
            Livro livro = Biblioteca.Livros.FirstOrDefault(x => x.ID == id);

            if (livro != null)
            {
                Biblioteca.Livros.Remove(livro);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Livro apagado"));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Livro não localizado"));
        }
    }
}
