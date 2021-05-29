using System.Collections.Generic;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.WebApp.Models
{
    public record KanbanViewModel(Folder Folder, List<Status> StatusList)
    { }
}