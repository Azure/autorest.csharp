using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtVirtualResourceTests : TestProjectTests
    {
        public MgmtVirtualResourceTests() : base("MgmtVirtualResource") { }

        [TestCase(false, "VirtualMachineMgmtVirtualResource", "Get")]
        [TestCase(false, "VirtualMachineMgmtVirtualResource", "GetAsync")]
        [TestCase(false, "VirtualMachineMgmtVirtualResource", "Delete")]
        [TestCase(false, "VirtualMachineMgmtVirtualResource", "DeleteAsync")]
        [TestCase(true, "VirtualMachineMgmtVirtualResource", "GetConfigurationProfileAssignments")]
        [TestCase(true, "VirtualMachineMgmtVirtualResource", "GetConfigurationProfileAssignment")]
        [TestCase(true, "VirtualMachineMgmtVirtualResource", "GetConfigurationProfileAssignmentAsync")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "Get")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "GetAsync")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "Delete")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "DeleteAsync")]
        [TestCase(true, "VirtualMachineScaleSetMgmtVirtualResource", "GetPublicIPAddresses")]
        [TestCase(true, "VirtualMachineScaleSetMgmtVirtualResource", "GetPublicIPAddressesAsync")]
        [TestCase(true, "MgmtVirtualResourceExtensions", "GetVirtualMachineMgmtVirtualResource")]
        [TestCase(true, "MgmtVirtualResourceExtensions", "GetVirtualMachineScaleSetMgmtVirtualResource")]
        public void ValidateMethod(bool exist, string className, string methodName)
        {
            var resource = Assembly.GetExecutingAssembly().GetType($"MgmtVirtualResource.{className}");
            Assert.NotNull(resource, $"Class {className} not found");

            var method = resource.GetMethod(methodName);
            Assert.AreEqual(exist, method != null, $"Method {methodName} should {(exist ? string.Empty : "not")} exist on class {className}");
        }

        [TestCase(false, "VirtualMachineMgmtVirtualResource", "HasData")]
        [TestCase(false, "VirtualMachineMgmtVirtualResource", "Data")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "HasData")]
        [TestCase(false, "VirtualMachineScaleSetMgmtVirtualResource", "Data")]
        public void ValidateProperty(bool exist, string className, string propertyName)
        {
            var resource = Assembly.GetExecutingAssembly().GetType($"MgmtVirtualResource.{className}");
            Assert.NotNull(resource, $"Class {className} not found");

            var property = resource.GetProperty(propertyName);
            Assert.AreEqual(exist, property != null, $"Property {propertyName} should {(exist ? string.Empty : "not")} exist on class {className}");
        }
    }
}
