namespace RequestOnRevision.Models
{
    /// <summary>
    /// Представляет разработанное приложение.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Идентификатор приложения.
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        ///  Название приложения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Разработчики.
        /// </summary>
        public string DevTeam { get; set; }
    }
}