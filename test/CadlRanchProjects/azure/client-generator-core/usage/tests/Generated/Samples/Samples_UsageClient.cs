// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
using _Specs_.Azure.ClientGenerator.Core.Usage.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Usage.Samples
{
    public class Samples_UsageClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput()
        {
            var client = new UsageClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = client.InputToInputOutput(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput_AllParameters()
        {
            var client = new UsageClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = client.InputToInputOutput(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.InputToInputOutputAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_AllParameters_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.InputToInputOutputAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_Convenience_Async()
        {
            var client = new UsageClient();

            var body = new InputModel("<name>");
            var result = await client.InputToInputOutputAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput()
        {
            var client = new UsageClient();

            Response response = client.OutputToInputOutput(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput_AllParameters()
        {
            var client = new UsageClient();

            Response response = client.OutputToInputOutput(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_Async()
        {
            var client = new UsageClient();

            Response response = await client.OutputToInputOutputAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_AllParameters_Async()
        {
            var client = new UsageClient();

            Response response = await client.OutputToInputOutputAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_Convenience_Async()
        {
            var client = new UsageClient();

            var result = await client.OutputToInputOutputAsync();
        }
    }
}
