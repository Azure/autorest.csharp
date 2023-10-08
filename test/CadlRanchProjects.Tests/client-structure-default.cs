using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Client.Structure.Service.Default;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ClientStructureDefaultTests : CadlRanchTestBase
    {
        [Test]
        public void Client_Structure_default_methods()
        {
            var methods = typeof(ServiceClient).GetMethods();
            Assert.IsNotNull(methods);
            Assert.AreEqual(6, methods.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            /* check the existance of the methods. */
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("OneAsync"));
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("TwoAsync"));
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("ThreeAsync"));
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("FourAsync"));
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("FiveAsync"));
            Assert.AreNotEqual(null, typeof(ServiceClient).GetMethod("SixAsync"));
        }

        [Test]
        public Task Client_Structure_default_One() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").OneAsync();
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Two() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").TwoAsync();
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Three() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").ThreeAsync();
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Four() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").FourAsync();
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Five() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").FiveAsync();
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Six() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, "default").SixAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
