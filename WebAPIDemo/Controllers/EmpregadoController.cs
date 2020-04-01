using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class EmpregadoController : ApiController
    {
        List<Empregado> Funcionarios;

        public EmpregadoController()
        {
            Funcionarios = new List<Empregado>
            {
                new Empregado {ID = 1, Nome = "Joana", Apelido = "Matos"},
                new Empregado {ID = 2, Nome = "Carlota", Apelido = "Morais"},
                new Empregado {ID = 3, Nome = "Rui", Apelido = "Santos"},
            };
        }

        // GET: api/Empregado
        /// <summary>
        /// Dados completos de todos os empregados
        /// </summary>
        /// <returns>Lista de todos os empregados</returns>
        public List<Empregado> Get()
        {
            return Funcionarios;
        }

        // GET: api/Empregado/5
        /// <summary>
        /// Dados completos do empregado
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>empregado consoante o id</returns>
        public Empregado Get(int id)
        {
            return Funcionarios.FirstOrDefault(x=>x.ID == id);
        }

        //GET: api/empregado/getnomes
        /// <summary>
        /// Nome próprio de todos os empregados
        /// </summary>
        /// <returns>Lista com os nomes de todos os empregados</returns>
        [Route("api/empregado/GetNomes")]
        public List<string> GetNomes()
        {
            List<string> output = new List<string>();

            foreach(var e in Funcionarios)
            {
                output.Add(e.Nome);
            }

            return output;
        }

        // POST: api/Empregado
        /// <summary>
        /// Registo de novo empregado
        /// </summary>
        /// <param name="valor">empregado</param>
        public void Post([FromBody]Empregado valor)
        {
            Funcionarios.Add(valor);
        }

        // DELETE: api/Empregado/5
        /// <summary>
        /// Apaga empregado consoante o id
        /// </summary>
        /// <param name="id">ID</param>
        public void Delete(int id)
        {

        }
    }
}
