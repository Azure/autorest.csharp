// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace security_key_LowLevel.Samples
{
    public class Samples_AutorestSecurityKeyClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AutorestSecurityKeyClient(credential);

            Response response = client.Head();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AutorestSecurityKeyClient(credential);

            Response response = client.Head();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AutorestSecurityKeyClient(credential);

            Response response = await client.HeadAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AutorestSecurityKeyClient(credential);

            Response response = await client.HeadAsync();
            Console.WriteLine(response.Status);
        }
    }
}
