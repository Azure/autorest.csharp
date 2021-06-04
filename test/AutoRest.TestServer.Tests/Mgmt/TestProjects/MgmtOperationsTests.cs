using System.Reflection;
using System.Threading;
using MgmtOperations.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtOperationsTests : TestProjectTests
    {
        public MgmtOperationsTests() : base("MgmtOperations") { }

        [TestCase("TestMethod")]
        [TestCase("TestMethodAsync")]
        public void ValidateTestMethod(string methodName)
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtOperations.AvailabilitySetOperations");
            var method = resourceOpreations.GetMethod(methodName);
            Assert.NotNull(method, $"{resourceOpreations.Name} does not implement the {methodName} method.");

            Assert.AreEqual(3, method.GetParameters().Length);
            var param1 = TypeAsserts.HasParameter(method, "requiredParam");
            Assert.AreEqual(typeof(string), param1.ParameterType);
            Assert.False(param1.IsOptional);
            var param2 = TypeAsserts.HasParameter(method, "optionalParam");
            Assert.AreEqual(typeof(string), param2.ParameterType);
            Assert.True(param2.IsOptional);
            var param3 = TypeAsserts.HasParameter(method, "cancellationToken");
            Assert.AreEqual(typeof(CancellationToken), param3.ParameterType);
        }

        [TestCase("TestLROMethod")]
        [TestCase("TestLROMethodAsync")]
        [TestCase("StartTestLROMethod")]
        [TestCase("StartTestLROMethodAsync")]
        public void ValidateLROMethod(string methodName)
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtOperations.AvailabilitySetOperations");
            var method = resourceOpreations.GetMethod(methodName);
            Assert.NotNull(method, $"{resourceOpreations.Name} does not implement the {methodName} method.");

            Assert.AreEqual(2, method.GetParameters().Length);
            var param1 = TypeAsserts.HasParameter(method, "parameters");
            Assert.AreEqual(typeof(AvailabilitySetUpdate), param1.ParameterType);
            Assert.False(param1.IsOptional);
            var param2 = TypeAsserts.HasParameter(method, "cancellationToken");
            Assert.AreEqual(typeof(CancellationToken), param2.ParameterType);
        }
    }
}
