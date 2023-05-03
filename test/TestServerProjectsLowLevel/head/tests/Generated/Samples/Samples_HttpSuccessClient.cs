// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace head_LowLevel.Samples
{
    public class Samples_HttpSuccessClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head200();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head204();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head404();
            Console.WriteLine(response.Status);
        }
    }
}
