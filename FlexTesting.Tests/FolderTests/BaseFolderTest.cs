using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Folder;
using FlexTesting.Tests.Mocks.FolderMocks;
using FlexTesting.Tests.Mocks.UserMocks;

namespace FlexTesting.Tests.FolderTests
{
    public abstract class BaseFolderTest
    {
        protected IFolderService _folderService;

        protected BaseFolderTest()
        {
            _folderService = new FolderService(
                new FolderGetOperationsMock(),
                new FolderWriteOperationsMock(),
                new UserGetOperationsMock());
        }
    }
}