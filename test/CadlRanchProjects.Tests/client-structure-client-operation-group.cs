using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Client.Structure.Service;
using Client.Structure.Service.ClientOperationGroup;
using Client.Structure.Service.ClientOperationGroup.Models;
using NUnit.Framework;


namespace CadlRanchProjects.Tests
{
    public class client_operation_group : CadlRanchTestBase
    {
        [Test]
        public void Client_Structure_Client_Operation_Group_methods()
        {
            /* check the methods in first client. */
            var methodsOfFirstClient = typeof(FirstClient).GetMethods();
            Assert.IsNotNull(methodsOfFirstClient);
            Assert.AreEqual(1, methodsOfFirstClient.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.AreNotEqual(null, typeof(FirstClient).GetMethod("OneAsync"));
            Assert.AreNotEqual(null, typeof(FirstClient).GetMethod("GetGroup3Client"));
            Assert.AreNotEqual(null, typeof(FirstClient).GetMethod("GetGroup4Client"));

            /* check the methods in Sub client. */
            var methodsOfSubClient = typeof(SubNamespaceSecondClient).GetMethods();
            Assert.IsNotNull(methodsOfSubClient);
            Assert.AreEqual(1, methodsOfSubClient.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.AreNotEqual(null, typeof(SubNamespaceSecondClient).GetMethod("FiveAsync"));
            Assert.AreNotEqual(null, typeof(SubNamespaceSecondClient).GetMethod("GetGroup5Client"));

            /*check methods in operation group3 client. */
            var methodsOfGroup3 = typeof(Group3).GetMethods();
            Assert.IsNotNull(methodsOfGroup3);
            Assert.AreEqual(2, methodsOfGroup3.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.AreNotEqual(null, typeof(Group3).GetMethod("TwoAsync"));
            Assert.AreNotEqual(null, typeof(Group3).GetMethod("ThreeAsync"));

            /*check methods in operation group4 client. */
            var methodsOfGroup4 = typeof(Group4).GetMethods();
            Assert.IsNotNull(methodsOfGroup4);
            Assert.AreEqual(1, methodsOfGroup4.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.AreNotEqual(null, typeof(Group4).GetMethod("FourAsync"));

            /*check methods in operation group5 client. */
            var methodsOfGroup5 = typeof(Group5).GetMethods();
            Assert.IsNotNull(methodsOfGroup5);
            Assert.AreEqual(1, methodsOfGroup5.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.AreNotEqual(null, typeof(Group5).GetMethod("SixAsync"));
        }

        [Test]
        public Task Client_Structure_OperationGroup_One() => Test(async (host) =>
        {
            Response response = await new FirstClient(host, ClientType.ClientOperationGroup).OneAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_OperationFroup_Two() => Test(async (host) =>
        {
            Response response = await new FirstClient(host, ClientType.ClientOperationGroup).GetGroup3Client().TwoAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_OperationFroup_Three() => Test(async (host) =>
        {
            Response response = await new FirstClient(host, ClientType.ClientOperationGroup).GetGroup3Client().ThreeAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_OperationFroup_Four() => Test(async (host) =>
        {
            Response response = await new FirstClient(host, ClientType.ClientOperationGroup).GetGroup4Client().FourAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_OperationFroup_Five() => Test(async (host) =>
        {
            Response response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup).FiveAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Client_Structure_OperationFroup_Six() => Test(async (host) =>
        {
            Response response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup).GetGroup5Client().SixAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
