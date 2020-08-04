using System.Reflection;
using NameConflicts.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class NameConflictTests
    {
        [Test]
        public void ExtensibleEnumNameDoesNotConflictWithPropertyNames()
        {
            var modelType = typeof(MyEnumValue);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);

            Assert.AreEqual(2, modelType.GetProperties().Length);
            var propInfo1 = TypeAsserts.HasProperty(modelType, "MyEnum", BindingFlags.Static | BindingFlags.Public);
            Assert.AreNotEqual(modelType.Name, propInfo1.Name);
            var propInfo2 = TypeAsserts.HasProperty(modelType, "SecondEnumValue", BindingFlags.Static | BindingFlags.Public);
            Assert.AreNotEqual(modelType.Name, propInfo2.Name);
        }
    }
}
