using System;
using System.Linq;
using Azure;
using MgmtLRO;
using MgmtLRO.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtLROTests : TestProjectTests
    {
        public MgmtLROTests() : base("MgmtLRO") { }

        [TestCase("BarContainer", "StartCreateOrUpdate", typeof(BarCreateOperation))]
        [TestCase("FakeContainer", "StartCreateOrUpdate", typeof(FakeCreateOrUpdateOperation))]
        [TestCase("BarContainer", "CreateOrUpdate", typeof(Response))]
        [TestCase("FakeContainer", "CreateOrUpdate", typeof(Response<Fake>))]
        public void ValidateLongRunningOperationFunctionInContainer(string className, string functionName, Type returnType)
        {
            var container = FindAllContainers().First(c => c.Name == className);
            var method = container.GetMethod(functionName);
            Assert.NotNull(method, $"cannot find {className}.{functionName}");
            Assert.AreEqual(method.ReturnType, returnType, $"method {className}.{functionName} does not return type {returnType}");
        }
    }
}
