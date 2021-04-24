namespace FlexTesting.Core.Contract.Source
{
    public enum SourceIds
    {
        Trello,
        Space,
        TargetProcess,
        YouTrack,
        Flex
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
        
        public static Models.Source FlexSource => new()
        {
            Id = SourceIds.Flex.ToString(),
            Name = "Flex"
        };
        
        //todo: Это точно норм?
    }
}