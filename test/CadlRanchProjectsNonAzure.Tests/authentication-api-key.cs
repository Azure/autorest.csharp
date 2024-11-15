// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Scm.Authentication.ApiKey;
using AutoRest.TestServer.Tests.Infrastructure;
using System.ClientModel;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class AuthenticationApiKeyTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Authentication_ApiKey_valid() => Test(async (host) =>
        {
            var response = await new ApiKeyClient(host, new ApiKeyCredential("valid-key"), null).ValidAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Authentication_ApiKey_invalid() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<ClientResultException>(() => new ApiKeyClient(host, new ApiKeyCredential("invalid-key"), null).InvalidAsync());
            Assert.AreEqual(403, exception.Status);
            return Task.CompletedTask;
        });
    }
}
