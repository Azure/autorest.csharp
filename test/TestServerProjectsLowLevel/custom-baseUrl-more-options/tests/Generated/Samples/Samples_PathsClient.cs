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

namespace custom_baseUrl_more_options_LowLevel.Samples
{
    public class Samples_PathsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient("<subscriptionId>", credential);

            Response response = client.GetEmpty("<vault>", "<secret>", "<keyName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient("<subscriptionId>", credential);

            Response response = client.GetEmpty("<vault>", "<secret>", "<keyName>", "<keyVersion>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient("<subscriptionId>", credential);

            Response response = await client.GetEmptyAsync("<vault>", "<secret>", "<keyName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient("<subscriptionId>", credential);

            Response response = await client.GetEmptyAsync("<vault>", "<secret>", "<keyName>", "<keyVersion>");
            Console.WriteLine(response.Status);
        }
    }
}
