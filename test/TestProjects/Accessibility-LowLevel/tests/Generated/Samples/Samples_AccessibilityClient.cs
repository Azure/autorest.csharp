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

namespace Accessibility_LowLevel.Samples
{
    public class Samples_AccessibilityClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AccessibilityClient(credential);

            var data = "<String>";

            Response response = client.Operation(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AccessibilityClient(credential);

            var data = "<String>";

            Response response = client.Operation(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AccessibilityClient(credential);

            var data = "<String>";

            Response response = await client.OperationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new AccessibilityClient(credential);

            var data = "<String>";

            Response response = await client.OperationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
