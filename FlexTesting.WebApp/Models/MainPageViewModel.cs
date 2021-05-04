using FlexTesting.Core.Contract.Models;

namespace FlexTesting.WebApp.Models
{
    public class MainPageViewModel
    {
        public User User { get; set; }
        public Folder[] Folders { get; set; }
    }
}