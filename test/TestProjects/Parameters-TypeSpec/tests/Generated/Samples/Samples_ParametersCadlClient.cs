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
using ParametersCadl.Models;

namespace ParametersCadl.Samples
{
    public class Samples_ParametersCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var client = new ParametersCadlClient();

            Response response = await client.OperationAsync(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var client = new ParametersCadlClient();

            Response response = await client.OperationAsync(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Convenience_Async()
        {
            var client = new ParametersCadlClient();

            var result = await client.OperationAsync(1234, 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation2()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation2(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation2_AllParameters()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation2(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation2_Async()
        {
            var client = new ParametersCadlClient();

            Response response = await client.Operation2Async(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation2_AllParameters_Async()
        {
            var client = new ParametersCadlClient();

            Response response = await client.Operation2Async(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation2_Convenience_Async()
        {
            var client = new ParametersCadlClient();

            var result = await client.Operation2Async(1234, 1234);
        }
    }
}
