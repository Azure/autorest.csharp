using System;
using Azure.ResourceManager.Resources.Models;
using MgmtSafeFlatten;
using MgmtSafeFlatten.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtSafeFlattenTests : TestProjectTests
    {
        public MgmtSafeFlattenTests() : base("MgmtSafeFlatten")
        {
        }

        [TestCase(typeof(TypeOneData), typeof(LayerTwoSingle), "LayerTwoMyProp", "MyProp")]
        [TestCase(typeof(TypeOneData), typeof(WritableSubResource), "LayerOneConflictId", "Id")]
        public void ValidatePropertyForwarder(Type newType, Type originalType, string newName, string originalName)
        {
            var newProperty = newType.GetProperty(newName);
            var originalProperty = originalType.GetProperty(originalName);
            Assert.AreEqual(originalProperty.CanRead, newProperty.CanRead, $"Expected {originalName} to have consistent getter, {newName} ({newProperty.CanRead}) and {originalName} ({originalProperty.CanRead})");
            Assert.AreEqual(originalProperty.CanWrite, newProperty.CanWrite, $"Expected {originalName} to have consistent setter, {newName} ({newProperty.CanWrite}) and {originalName} ({originalProperty.CanWrite})");
            Assert.AreEqual(originalProperty.PropertyType, newProperty.PropertyType, $"Expected {originalName} to have consistent type, {newName} ({newProperty.PropertyType.Name}) and {originalName} ({originalProperty.PropertyType.Name})");
        }
    }
}
