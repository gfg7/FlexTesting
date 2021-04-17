using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Framework.Contract.Input
{
    public record LoginDto([Required] string Login,[Required] string Password)
    { }
}