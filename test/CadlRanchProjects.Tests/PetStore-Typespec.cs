﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using PetStore;
using NUnit.Framework;
using Azure;
using PetStore.Models;

namespace CadlRanchProjects.Tests
{
    public class PetStoreCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task PetStore_DeletePetById() => Test(async (host) =>
        {
            Response response = await new PetStoreClient(host, null).DeleteAsync(1);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task PetStore_ReadPetById() => Test(async (host) =>
        {
            Response response = await new PetStoreClient(host, null).ReadAsync(1, new RequestContext());
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(12, Pet.FromResponse(response).Age);
            Assert.AreEqual("dog", Pet.FromResponse(response).Name);
        });

        [Test]
        public Task PetStore_CreatePet() => Test(async (host) =>
        {
            Pet pet = new("dog", 12);
            var response = await new PetStoreClient(host, null).CreateAsync(pet);
            Assert.AreEqual("dog", response.Value.Name);
            Assert.AreEqual(12, response.Value.Age);
        });

        [Test]
        public Task PetStore_GetPetByKind() => Test(async (host) =>
        {
            Pet pet = new("dog", 12);
            Response response = await new PetStoreClient(host, null).GetPetByKindAsync("dog");
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(12, Pet.FromResponse(response).Age);
            Assert.AreEqual("dog", Pet.FromResponse(response).Name);
        });

        [Test]
        public Task PetStore_GetFirstPet() => Test(async (host) =>
        {
            Pet pet = new("dog", 12);
            Response response = await new PetStoreClient(host, null).GetFirstPetAsync(1, new RequestContext());
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(12, Pet.FromResponse(response).Age);
            Assert.AreEqual("dog", Pet.FromResponse(response).Name);
        });
    }
}
