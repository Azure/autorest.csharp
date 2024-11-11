using System;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Page;
using _Specs_.Azure.Example.Basic;
using _Specs_.Azure.Example.Basic.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class azure_example_client_basic : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Example_Client_BasicAction() => Test(async (host) =>
        {
            var request = new ActionRequest("text")
            {
                ModelProperty = new Model()
                {
                    EnumProperty = _Specs_.Azure.Example.Basic.Models.Enum.EnumValue1,
                    Int32Property = 1,
                    Float32Property = 1.5f,
                },
                ArrayProperty =
                {
                    "item"
                },
                RecordProperty =
                {
                    { "record", "value" }
                }
            };
            var response = await new AzureExampleClient(host, null).BasicActionAsync("query", "header", request);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("text", response.Value.StringProperty);
        });
    }
}
