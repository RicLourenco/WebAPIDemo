using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    /// <summary>
    /// Classe que contém a lista onde estão guardados todos os livros
    /// </summary>
    public class Biblioteca
    {
        private static List<Livro> livros;

        /// <summary>
        /// Propriedade que gera os livros caso ainda não existam, e os mostra caso já existam
        /// </summary>
        public static List<Livro> Livros
        {
            get
            {
                if(livros == null)
                {
                    GerarLivros();
                }

                return livros;
            }
            set { livros = value; }
        }

        /// <summary>
        /// Método que gera os livros caso não existam
        /// </summary>
        private static void GerarLivros()
        {
            livros = new List<Livro>();

            livros.Add(new Livro
            { 
                ID = 1,
                Titulo = "Eu e as minhas irmãs",
                Autor = "Rui Mendes"
            });

            livros.Add(new Livro
            {
                ID = 2,
                Titulo = "Eu e os meus irmãos",
                Autor = "Rui Jota"
            });

            livros.Add(new Livro
            {
                ID = 3,
                Titulo = "As minhas irmãs e eu",
                Autor = "Jota Rui"
            });
        }
    }
}