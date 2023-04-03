// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Hello;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class HelloTests : CadlRanchTestBase
    {
        [Test]
        public Task Hello_world() => Test(async (host) =>
        {
            string response = await new HelloClient(host, null).WorldValueAsync();
            Assert.AreEqual("Hello World!", response);
        });
    }
}
