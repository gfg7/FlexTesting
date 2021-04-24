namespace FlexTesting.Core.Contract.Models
{
    /// <summary>
    /// Токены пользователя для взаимодействия с внешними системами
    /// </summary>
    public record Token : IModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SourceId { get; set; }
        /// <summary>
        /// информация о токене в формате Json, у разных систем могут быть разные объекты
        /// </summary>
        public string Payload { get; set; }
    }
}