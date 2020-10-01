using ModelNamespace;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ModelNamespaceTests
    {
        [Test]
        public void ExcludeModelNamespace()
        {
            var modelType = typeof(TestModel);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("ModelNamespace", modelType.Namespace);

        }
    }
}
