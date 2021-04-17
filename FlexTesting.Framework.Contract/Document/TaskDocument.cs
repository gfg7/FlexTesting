using FlexTesting.Framework.Contract.Document.Enums;

namespace FlexTesting.Framework.Contract.Document
{
    public class TaskDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }

        /// <summary>
        /// Источник задачи
        /// </summary>
        public TaskSource Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Ссылка на статус
        /// </summary>
        public string StatusId { get; set; }
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}