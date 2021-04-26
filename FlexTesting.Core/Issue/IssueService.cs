using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Issue.Dtos;
using FlexTesting.Core.Contract.TaskStatus;
using HarabaSourceGenerators.Common.Attributes;

namespace FlexTesting.Core.Issue
{
    [Inject]
    public partial class IssueService : IIssueService
    {
        private readonly IIssueGetOperations _issueGetOperations;
        private readonly IIssueWriteOperations _issueWriteOperations;
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly ITaskStatusGetOperations _taskStatusGetOperations;
        
        public async Task<Contract.Models.Issue> Create(CreateIssueDto createIssueDto)
        {
            ValidationHelper.ValidateAndThrow(createIssueDto);
            if (!await _folderGetOperations.ExistsById(createIssueDto.FolderId))
            {
                throw new NotFoundException("Директория не найдена");
            }

            if (!await _taskStatusGetOperations.ExistsById(createIssueDto.StatusId))
            {
                throw new NotFoundException("Статус не найден");
            }

            var model = new Contract.Models.Issue()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createIssueDto.Name,
                Description = createIssueDto.Description,
                ExternalId = createIssueDto.ExternalId,
                FolderId = createIssueDto.FolderId,
                StatusId = createIssueDto.StatusId
            };

            return await _issueWriteOperations.Create(model);
        }

        public async Task<Contract.Models.Issue> ChangeStatus(ChangeStatusDto changeStatusDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Issue> ChangeInfo(ChangeIssueInfoDto changeIssueInfoDto)
        {
            throw new System.NotImplementedException();
        }
    }
}