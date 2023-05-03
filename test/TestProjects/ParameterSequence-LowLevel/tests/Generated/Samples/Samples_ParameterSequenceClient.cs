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

namespace ParameterSequence_LowLevel.Samples
{
    public class Samples_ParameterSequenceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItem()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParameterSequenceClient(credential);

            Response response = client.GetItem("<itemName>", "<origin>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SelectItem()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParameterSequenceClient(credential);

            Response response = client.SelectItem("<itemName>", "<origin>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
