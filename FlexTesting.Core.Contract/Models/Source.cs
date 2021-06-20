namespace FlexTesting.Core.Contract.Models
{
    /// <summary>
    /// Источники задач, внешние системы 
    /// </summary>
    public record Source : IModel
    {
        // техническая сущность, справочник, не имеет бизнес-логики
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public string MainUrl { get; set; }
    }
}