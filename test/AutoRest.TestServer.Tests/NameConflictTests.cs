using System.Reflection;
using AutoRest.TestServer.Tests.Infrastructure;
using NameConflicts;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class NameConflictTests
    {
        [Test]
        public void ExtensibleEnumNameDoesNotConflictWithPropertyNames()
        {
            var modelType = TestServerTestBase.FindType(typeof(AutoRestParameterFlatteningClient).Assembly, "ItemValue");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);

            Assert.AreEqual(3, modelType.GetProperties().Length);
            var propInfo1 = TypeAsserts.HasProperty(modelType, "ItemValue1", BindingFlags.Static | BindingFlags.Public);
            Assert.AreNotEqual(modelType.Name, propInfo1.Name);
            var propInfo2 = TypeAsserts.HasProperty(modelType, "Item", BindingFlags.Static | BindingFlags.Public);
            Assert.AreNotEqual(modelType.Name, propInfo2.Name);
            var propInfo3 = TypeAsserts.HasProperty(modelType, "ItemValue2", BindingFlags.Static | BindingFlags.Public);
            Assert.AreNotEqual(modelType.Name, propInfo3.Name);
        }
    }
}
