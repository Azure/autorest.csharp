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
            TypeAsserts.HasProperty(modelType, "MyEnum", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "SecondEnumValue", BindingFlags.Static | BindingFlags.Public);
        }
    }
}
