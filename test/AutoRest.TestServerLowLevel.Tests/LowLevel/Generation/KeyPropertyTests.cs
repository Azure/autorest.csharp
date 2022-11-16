using System;
using System.Reflection;
using ModelsInCadl;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class KeyPropertyTests
    {
        [TestCase(typeof(RoundTripPrimitiveModel), "RequiredString")]
        [TestCase(typeof(OutputModel), "RequiredModel")]
        public void ShouldBeReadOnly(Type type, string name)
        {

            var propertyInfo = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(propertyInfo);
            Assert.IsTrue(propertyInfo.CanRead);
            Assert.IsFalse(propertyInfo.CanWrite);
        }
    }
}
