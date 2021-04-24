using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.Source
{
    public interface ISourceGetOperations : IGetOperations<Models.Source>
    {
        public Task<Models.Source> ByName(string name);
    }
}