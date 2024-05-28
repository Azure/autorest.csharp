// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using PetStore;
using NUnit.Framework;
using Azure;
using PetStore.Models;

namespace CadlRanchProjects.Tests
{
    public class PetStoreTypeSpecTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task PetStore_CreatePet() => Test(async (host) =>
        {
            Pet pet = new("dog", 12);
            var response = await new PetStoreClient(host, null).GetPetsClient().CreateAsync(pet);
            Assert.AreEqual("dog", response.Value.Name);
            Assert.AreEqual(12, response.Value.Age);
        });
    }
}
