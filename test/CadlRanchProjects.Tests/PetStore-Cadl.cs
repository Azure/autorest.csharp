// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using PetStore;
using NUnit.Framework;
using Azure;

namespace CadlRanchProjects.Tests
{
    public class PetStoreCadlTests : CadlRanchTestBase
    {
        [Test]
        public Task PetStoreCadl_DeleteAPetById() => Test(async (host) =>
        {
            Response response = await new PetStoreClient(host, null).DeleteAsync(1);
            Assert.AreEqual(200, response.Status);
        });
    }
}
