using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Parameters.Basic;
using Parameters.Basic.Models;

namespace CadlRanchProjects.Tests
{
    public class parameter_basic : CadlRanchTestBase
    {
        [Test]
        public Task Parameters_Basic_ExplicitBody() => Test(async (host) =>
        {
            Response response = await new BasicClient(host, null).GetExplicitBodyClient().SimpleAsync(new User("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Basic_implicitBody() => Test(async (host) =>
        {
            Response response = await new BasicClient(host, null).GetImplicitBodyClient().SimpleAsync("foo");
            Assert.AreEqual(204, response.Status);
        });
    }
}
