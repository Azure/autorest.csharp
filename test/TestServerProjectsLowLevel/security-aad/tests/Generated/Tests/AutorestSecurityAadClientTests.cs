// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using security_aad_LowLevel;

namespace security_aad_LowLevel.Tests
{
    public class AutorestSecurityAadClientTests : security_aad_LowLevelTestBase
    {
        public AutorestSecurityAadClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Head_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AutorestSecurityAadClient client = CreateAutorestSecurityAadClient(credential, endpoint);

            Response response = await client.HeadAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Head_AllParameters_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AutorestSecurityAadClient client = CreateAutorestSecurityAadClient(credential, endpoint);

            Response response = await client.HeadAsync();
            Console.WriteLine(response.Status);
        }
    }
}
