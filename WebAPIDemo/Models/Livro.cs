namespace WebAPIDemo.Models
{
    /// <summary>
    /// Objeto Livro que tem um ID, Título e Autor
    /// </summary>
    public class Livro
    {
        /// <summary>
        /// ID do livro
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Título do livro
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Autor do livro
        /// </summary>
        public string Autor { get; set; }
    }
}