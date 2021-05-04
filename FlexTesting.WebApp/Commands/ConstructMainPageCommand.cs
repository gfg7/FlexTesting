using System;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.User;
using FlexTesting.WebApp.Models;
using HarabaSourceGenerators.Common.Attributes;

namespace FlexTesting.WebApp.Commands
{
    [Inject]
    public partial class ConstructMainPageCommand
    {
        private readonly IUserService _userService;
        private readonly IFolderService _folderService;

        public async Task<MainPageViewModel> ConstructMainPage(string userToken)
        {
            var user = await _userService.GetCurrentUser(userToken);
                var folders = await _folderService.GetByUser(user.Id);

                return new MainPageViewModel
                {
                    User = user,
                    Folders = folders.ToArray()
                };
        }
    }
}