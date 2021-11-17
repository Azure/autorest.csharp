using System.Reflection;
using System.Threading;
using MgmtOperations.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtOperationsTests : TestProjectTests
    {
        public MgmtOperationsTests() : base("MgmtOperations") { }

        [TestCase("TestSetSharedKey")]
        [TestCase("TestSetSharedKeyAsync")]
        public void ValidatePutMethod(string methodName)
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtOperations.AvailabilitySet");
            var method = resourceOpreations.GetMethod(methodName);
            Assert.NotNull(method, $"{resourceOpreations.Name} does not implement the {methodName} method.");

            Assert.AreEqual(3, method.GetParameters().Length);
            var param1 = TypeAsserts.HasParameter(method, "parameters");
            Assert.AreEqual(typeof(ConnectionSharedKey), param1.ParameterType);
            Assert.False(param1.IsOptional);
            var param2 = TypeAsserts.HasParameter(method, "waitForCompletion");
            Assert.AreEqual(typeof(bool), param2.ParameterType);
            var param3 = TypeAsserts.HasParameter(method, "cancellationToken");
            Assert.AreEqual(typeof(CancellationToken), param3.ParameterType);
        }
    }
}
