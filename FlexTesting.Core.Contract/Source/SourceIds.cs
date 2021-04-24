namespace FlexTesting.Core.Contract.Source
{
    public enum SourceIds
    {
        Trello,
        Space,
        TargetProcess,
        YouTrack
    }

    public class Sources
    {
        public static Models.Source TrelloSource => new()
        {
            Id = SourceIds.Trello.ToString(),
            ApiUrl = "https://api/url",
            MainUrl = "https://main/url",
            Name = "Trello"
        };
        public static Models.Source SpaceSource => new()
        {
            Id = SourceIds.Space.ToString(),
            ApiUrl = "https://api/url",
            MainUrl = "https://main/url",
            Name = "JetBrains Space"
        };
        
        //todo: Это точно норм?
    }
}