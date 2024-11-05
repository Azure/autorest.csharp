using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Client.Structure.Service;
using Client.Structure.Service.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ClientStructureDefaultTests : CadlRanchTestBase
    {
        [TestCase(typeof(ServiceClient), new string[] { "One", "Two" })]
        [TestCase(typeof(Foo), new string[] { "Three", "Four" })]
        [TestCase(typeof(Bar), new string[] { "Five", "Six" })]
        [TestCase(typeof(BazFoo), new string[] {"Seven"})]
        [TestCase(typeof(Qux), new string[] {"Eight"})]
        [TestCase(typeof(QuxBar), new string[] {"Nine"})]

        public void Client_Structure_default_methods(Type client, string[] methodNames)
        {
           var methods = client.GetMethods();
           Assert.IsNotNull(methods);
           Assert.AreEqual(methodNames.Length, methods.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
           /* check the existence of the methods. */
           foreach (var methodName in methodNames)
           {
               Assert.IsNotNull(client.GetMethod($"{methodName}Async"));
           }
        }

        [Test]
        public Task Client_Structure_default_One() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).OneAsync();
           Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Two() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).TwoAsync();
           Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Three() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).GetFooClient().ThreeAsync();
           Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Four() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).GetFooClient().FourAsync();
           Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Five() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).GetBarClient().FiveAsync();
           Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Client_Structure_default_Six() => Test(async (host) =>
        {
           Response response = await new ServiceClient(host, ClientType.Default).GetBarClient().SixAsync();
           Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_default_Seven() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, ClientType.Default).GetBazClient().GetBazFooClient().SevenAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_default_Eight() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, ClientType.Default).GetQuxClient().EightAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_default_Nine() => Test(async (host) =>
        {
            Response response = await new ServiceClient(host, ClientType.Default).GetQuxClient().GetQuxBarClient().NineAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
