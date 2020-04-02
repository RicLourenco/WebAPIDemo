namespace WebAPIDemo.Models
{
    /// <summary>
    /// Objeto Empregado que tem um ID, Nome e Apelido
    /// </summary>
    public class Empregado
    {
        /// <summary>
        /// ID do empregado
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome do empregado
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Apelido do empregado
        /// </summary>
        public string Apelido { get; set; }
    }
}