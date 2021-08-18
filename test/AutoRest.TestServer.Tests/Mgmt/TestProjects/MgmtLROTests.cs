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

        [TestCase("BarContainer", "CreateOrUpdate", typeof(BarCreateOperation))]
        [TestCase("FakeContainer", "CreateOrUpdate", typeof(FakeCreateOrUpdateOperation))]
        public void ValidateLongRunningOperationFunctionInContainer(string className, string functionName, Type returnType)
        {
            var container = FindAllContainers().First(c => c.Name == className);
            var method = container.GetMethod(functionName);
            Assert.NotNull(method, $"cannot find {className}.{functionName}");
            Assert.AreEqual(method.ReturnType, returnType, $"method {className}.{functionName} does not return type {returnType}");
        }

        [TestCase("FakeContainer", "CreateOrUpdate")]
        [TestCase("Fake", "Delete")]
        [TestCase("BarContainer", "CreateOrUpdate")]
        [TestCase("Bar", "Update")]
        public void ValidateSLROMethods(string className, string methodName)
        {
            ValidateMethods(className, methodName, true, true);
        }

        [TestCase("Fake", "StartUpdate")]
        [TestCase("Bar", "StartDelete")]
        public void ValidateLROMethods(string className, string methodName)
        {
            ValidateMethods(className, methodName, true, false);
        }

        public void ValidateMethods(string className, string methodName, bool exist, bool isSLRO)
        {
            var classesToCheck = FindAllContainers().Concat(FindAllResources());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            var methodInfo = classToCheck.GetMethod(methodName);
            Assert.AreEqual(exist, methodInfo != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");

            var waitForCompletionParam = methodInfo.GetParameters().Where(P => P.Name == "waitForCompletion").First();
            Assert.NotNull(waitForCompletionParam);
            if (isSLRO)
            {
                Assert.False(methodInfo.Name.StartsWith("Start"));
                Assert.AreEqual(true, waitForCompletionParam.DefaultValue);
            }
            else
            {
                Assert.True(methodInfo.Name.StartsWith("Start"));
                Assert.AreEqual(false, waitForCompletionParam.DefaultValue);
            }
        }
    }
}
