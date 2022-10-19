﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using api_key;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CadlRanchProjects.Tests
{
    public class api_key : CadlRanchTestBase
    {
        [Test]
        public Task Authentication_ApiKey_valid() => Test(async (host) =>
        {
            Response response = await new ApiKeyClient(new AzureKeyCredential("valid-key"), host, null).ValidAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Authentication_ApiKey_invalid() => Test(async (host) =>
        {
            Response response = await new ApiKeyClient(new AzureKeyCredential("valid-key"), host, null).InvalidAsync();
            Assert.AreEqual("invalid-api-key", InvalidAuth.FromResponse(response).Error);
        });
    }
}
