using FlexTesting.Core.Contract.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.HelperTests
{
    public class ExtensionsTest
    {
        [Test]
        public void TestSelector()
        {
            var s = "Добавить приложение 123  @@ ^5".FormatToSelector();
        }
    }
}