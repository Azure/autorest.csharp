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
using ParametersCadl;
using ParametersCadl.Models;

namespace ParametersCadl.Samples
{
    public partial class Samples_ParametersCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation_ShortVersion()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = client.Operation(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation_ShortVersion_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = await client.OperationAsync(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation_ShortVersion_Convenience()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = client.Operation(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation_ShortVersion_Convenience_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = await client.OperationAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation_AllParameters()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = client.Operation(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation_AllParameters_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = await client.OperationAsync(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation_AllParameters_Convenience()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = client.Operation(1234, end: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation_AllParameters_Convenience_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = await client.OperationAsync(1234, end: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation2_ShortVersion()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = client.Operation2(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation2_ShortVersion_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = await client.Operation2Async(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation2_ShortVersion_Convenience()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = client.Operation2(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation2_ShortVersion_Convenience_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = await client.Operation2Async(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation2_AllParameters()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = client.Operation2(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation2_AllParameters_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response response = await client.Operation2Async(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParameterOrders_Operation2_AllParameters_Convenience()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = client.Operation2(1234, start: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParameterOrders_Operation2_AllParameters_Convenience_Async()
        {
            ParametersCadlClient client = new ParametersCadlClient();

            Response<Result> response = await client.Operation2Async(1234, start: 1234);
        }
    }
}
