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

namespace ParametersCadl.Tests
{
    public class ParametersCadlClientTests : ParametersCadlTestBase
    {
        public ParametersCadlClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Operation_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response response = await client.OperationAsync(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        public async Task Operation_Convenience_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response<Result> response = await client.OperationAsync(1234);
        }

        [Test]
        public async Task Operation_AllParameters_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response response = await client.OperationAsync(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        public async Task Operation_AllParameters_Convenience_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response<Result> response = await client.OperationAsync(1234, end: 1234);
        }

        [Test]
        public async Task Operation2_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response response = await client.Operation2Async(1234, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        public async Task Operation2_Convenience_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response<Result> response = await client.Operation2Async(1234);
        }

        [Test]
        public async Task Operation2_AllParameters_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response response = await client.Operation2Async(1234, 1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        public async Task Operation2_AllParameters_Convenience_Async()
        {
            ParametersCadlClient client = CreateParametersCadlClient();

            Response<Result> response = await client.Operation2Async(1234, start: 1234);
        }
    }
}
