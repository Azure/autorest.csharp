using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ResourceRename;
using ResourceRename.Models;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ResourceRenameTests : TestProjectTests
    {
        public ResourceRenameTests() : base("ResourceRename") { }

        [Test]
        public void RenamedModelExists()
        {
            var modelType = typeof(SshPublicKeyInfo);
            Assert.NotNull(modelType);
        }

        [Test]
        public void OldModelDoesNotExist()
        {
            var modelType = typeof(SshPublicKeyInfo);
            Assert.Null(modelType.Assembly.GetType("SshPublicKeyResource"));
        }

        [TestCase(typeof(AnyObjectTests), "AnyProperty", typeof(BinaryData))]
        [TestCase(typeof(AnyObjectTests), "AnyObjectProperty", typeof(BinaryData))]
        [TestCase(typeof(AnyObjectTests), "AnyList", typeof(IReadOnlyList<BinaryData>))]
        [TestCase(typeof(AnyObjectTests), "AnyObjectList", typeof(IReadOnlyList<BinaryData>))]
        [TestCase(typeof(AnyObjectTests), "AnyDictionary", typeof(IReadOnlyDictionary<string, BinaryData>))]
        [TestCase(typeof(AnyObjectTests), "AnyObjectDictionary", typeof(BinaryData))] //we changed this one in swagger directive
        public void ValidatePropertyType(Type model, string propertyName, Type expectedPropertyType)
        {
            var property = model.GetProperty(propertyName);
            Assert.NotNull(property);
            Assert.AreEqual(expectedPropertyType, property.PropertyType);
        }
    }
}
