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

namespace Accessibility_LowLevel.Samples
{
    public partial class Samples_AccessibilityClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_Operation_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            using RequestContent content = null;
            Response response = client.Operation(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Operation_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            using RequestContent content = null;
            Response response = await client.OperationAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_Operation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            using RequestContent content = RequestContent.Create("<body>");
            Response response = client.Operation(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            using RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OperationAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
