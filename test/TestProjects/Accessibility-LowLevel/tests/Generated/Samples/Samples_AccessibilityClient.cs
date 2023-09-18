// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Accessibility_LowLevel;
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
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            RequestContent content = null;
            Response response = client.Operation(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            RequestContent content = null;
            Response response = await client.OperationAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = client.Operation(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AccessibilityClient client = new AccessibilityClient(credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OperationAsync(content);
            Console.WriteLine(response.Status);
        }
    }
}
