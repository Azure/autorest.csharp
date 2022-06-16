using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtPartialResourceTests : TestProjectTests
    {
        public MgmtPartialResourceTests() : base("MgmtPartialResource") { }

        [TestCase(false, "VirtualMachineMgmtPartialResource", "Get")]
        [TestCase(false, "VirtualMachineMgmtPartialResource", "GetAsync")]
        [TestCase(false, "VirtualMachineMgmtPartialResource", "Delete")]
        [TestCase(false, "VirtualMachineMgmtPartialResource", "DeleteAsync")]
        [TestCase(true, "VirtualMachineMgmtPartialResource", "GetConfigurationProfileAssignments")]
        [TestCase(true, "VirtualMachineMgmtPartialResource", "GetConfigurationProfileAssignment")]
        [TestCase(true, "VirtualMachineMgmtPartialResource", "GetConfigurationProfileAssignmentAsync")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "Get")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "GetAsync")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "Delete")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "DeleteAsync")]
        [TestCase(true, "VirtualMachineScaleSetMgmtPartialResource", "GetPublicIPAddresses")]
        [TestCase(true, "VirtualMachineScaleSetMgmtPartialResource", "GetPublicIPAddressesAsync")]
        [TestCase(true, "MgmtPartialResourceExtensions", "GetVirtualMachineMgmtPartialResource")]
        [TestCase(true, "MgmtPartialResourceExtensions", "GetVirtualMachineScaleSetMgmtPartialResource")]
        public void ValidateMethod(bool exist, string className, string methodName)
        {
            var resource = Assembly.GetExecutingAssembly().GetType($"MgmtPartialResource.{className}");
            Assert.NotNull(resource, $"Class {className} not found");

            var method = resource.GetMethod(methodName);
            Assert.AreEqual(exist, method != null, $"Method {methodName} should {(exist ? string.Empty : "not")} exist on class {className}");
        }

        [TestCase(false, "VirtualMachineMgmtPartialResource", "HasData")]
        [TestCase(false, "VirtualMachineMgmtPartialResource", "Data")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "HasData")]
        [TestCase(false, "VirtualMachineScaleSetMgmtPartialResource", "Data")]
        public void ValidateProperty(bool exist, string className, string propertyName)
        {
            var resource = Assembly.GetExecutingAssembly().GetType($"MgmtPartialResource.{className}");
            Assert.NotNull(resource, $"Class {className} not found");

            var property = resource.GetProperty(propertyName);
            Assert.AreEqual(exist, property != null, $"Property {propertyName} should {(exist ? string.Empty : "not")} exist on class {className}");
        }
    }
}
