using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtLROTests : TestProjectTests
    {
        public MgmtLROTests() : base("MgmtLRO") { }

        [TestCase("BarContainer", "StartCreateOrUpdate", "BarsDoSomethingOperation")]
        [TestCase("FakeContainer", "StartCreateOrUpdate", "FakesCreateOrUpdateOperation")]
        public void ValidateLongRunningOperationFunctionInContainer(string className, string functionName, string returnTypeName)
        {
            var container = FindAllContainers().First(c => c.Name == className);
            var method = container.GetMethod(functionName);
            Assert.NotNull(method, $"cannot find {className}.{functionName}");
            Assert.AreEqual(method.ReturnType.Name, returnTypeName, $"method {className}.{functionName} does not return type {returnTypeName}");
        }
    }
}
