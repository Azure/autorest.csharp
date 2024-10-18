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
