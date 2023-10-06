// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using ParameterSequence_LowLevel;

namespace ParameterSequence_LowLevel.Samples
{
    public partial class Samples_ParameterSequenceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItem_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = client.GetItem("<itemName>", "<origin>", null, null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItem_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = await client.GetItemAsync("<itemName>", "<origin>", null, null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItem_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = client.GetItem("<itemName>", "<origin>", "<version>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItem_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = await client.GetItemAsync("<itemName>", "<origin>", "<version>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SelectItem_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = client.SelectItem("<itemName>", "<origin>", null, null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SelectItem_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = await client.SelectItemAsync("<itemName>", "<origin>", null, null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SelectItem_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = client.SelectItem("<itemName>", "<origin>", "<version>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SelectItem_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("ParameterSequenceClient_KEY"));
            ParameterSequenceClient client = new ParameterSequenceClient(credential);

            Response response = await client.SelectItemAsync("<itemName>", "<origin>", "<version>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }
    }
}
