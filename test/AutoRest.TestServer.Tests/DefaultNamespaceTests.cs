using DefaultNamespace;
using DefaultNamespace.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class DefaultNamespaceTests
    {
        [Test]
        public void ClientUsesDefaultNamespace()
        {
            var clientType = typeof(DefaultNamespaceClient);
            Assert.AreEqual("DefaultNamespace", clientType.Namespace);
        }

        [Test]
        public void ModelUsesDefaultNamespace()
        {
            var modelType = typeof(Model);
            Assert.AreEqual("DefaultNamespace.Models", modelType.Namespace);
        }
    }
}
