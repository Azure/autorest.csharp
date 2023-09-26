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

namespace security_aad_LowLevel.Samples
{
    public class Samples_AutorestSecurityAadClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head()
        {
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = new AutorestSecurityAadClient(credential);

            Response response = client.Head();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = new AutorestSecurityAadClient(credential);

            Response response = await client.HeadAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head_AllParameters()
        {
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = new AutorestSecurityAadClient(credential);

            Response response = client.Head();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head_AllParameters_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = new AutorestSecurityAadClient(credential);

            Response response = await client.HeadAsync();

            Console.WriteLine(response.Status);
        }
    }
}
