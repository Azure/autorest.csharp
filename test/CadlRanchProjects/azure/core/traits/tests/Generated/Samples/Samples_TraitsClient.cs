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
using _Specs_.Azure.Core.Traits.Models;

namespace _Specs_.Azure.Core.Traits.Samples
{
    public class Samples_TraitsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SmokeTest()
        {
            var client = new TraitsClient();

            Response response = client.SmokeTest(1234, "<foo>", null, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SmokeTest_AllParameters()
        {
            var client = new TraitsClient();

            Response response = client.SmokeTest(1234, "<foo>", null, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SmokeTest_Async()
        {
            var client = new TraitsClient();

            Response response = await client.SmokeTestAsync(1234, "<foo>", null, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SmokeTest_AllParameters_Async()
        {
            var client = new TraitsClient();

            Response response = await client.SmokeTestAsync(1234, "<foo>", null, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SmokeTest_Convenience_Async()
        {
            var client = new TraitsClient();

            var result = await client.SmokeTestAsync(1234, "<foo>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RepeatableAction()
        {
            var client = new TraitsClient();

            var data = new
            {
                userActionValue = "<userActionValue>",
            };

            Response response = client.RepeatableAction(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("userActionResult").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RepeatableAction_AllParameters()
        {
            var client = new TraitsClient();

            var data = new
            {
                userActionValue = "<userActionValue>",
            };

            Response response = client.RepeatableAction(1234, RequestContent.Create(data), "<repeatabilityRequestId>", DateTimeOffset.UtcNow);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("userActionResult").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RepeatableAction_Async()
        {
            var client = new TraitsClient();

            var data = new
            {
                userActionValue = "<userActionValue>",
            };

            Response response = await client.RepeatableActionAsync(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("userActionResult").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RepeatableAction_AllParameters_Async()
        {
            var client = new TraitsClient();

            var data = new
            {
                userActionValue = "<userActionValue>",
            };

            Response response = await client.RepeatableActionAsync(1234, RequestContent.Create(data), "<repeatabilityRequestId>", DateTimeOffset.UtcNow);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("userActionResult").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RepeatableAction_Convenience_Async()
        {
            var client = new TraitsClient();

            var userActionParam = new UserActionParam("<userActionValue>");
            var result = await client.RepeatableActionAsync(1234, userActionParam, "<repeatabilityRequestId>", DateTimeOffset.UtcNow);
        }
    }
}
