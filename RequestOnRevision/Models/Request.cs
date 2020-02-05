using System;

namespace RequestOnRevision.Models
{
    /// <summary>
    /// Представляет заявку на изменение приложения.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Идентификатор запроса.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Имя запроса.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Идентификатор приложения.
        /// </summary>
        public int ApplicationId { get; set; }

        public virtual Application ApplicationInfo { get; set; }

        /// <summary>
        /// Дата окончания разработки.
        /// </summary>
        public DateTime DevEndDate { get; set; }

        /// <summary>
        /// Описание заявки.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}