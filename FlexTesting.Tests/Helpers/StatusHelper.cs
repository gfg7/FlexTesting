using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Source;

namespace FlexTesting.Tests.Helpers
{
    public static class StatusHelper
    {
        public static TaskStatus ValidStatus => new()
        {
            Name = "Todo",
            Id = "validstatus",
            SourceId = SourceIds.Flex.ToString()
        };

        public static TaskStatus DeletionStatus => new()
        {
            Name = "Del",
            Id = "delstatus",
            SourceId = SourceIds.Flex.ToString()
        };
    }
}