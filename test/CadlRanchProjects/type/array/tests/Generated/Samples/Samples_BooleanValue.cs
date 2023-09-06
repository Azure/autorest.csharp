// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type._Array;

namespace _Type._Array.Samples
{
    internal class Samples_BooleanValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = client.GetBooleanValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_AllParameters()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = client.GetBooleanValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_Convenience()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<bool>> response = client.GetBooleanValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_AllParameters_Convenience()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<bool>> response = client.GetBooleanValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = await client.GetBooleanValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_AllParameters_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = await client.GetBooleanValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_Convenience_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<bool>> response = await client.GetBooleanValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_AllParameters_Convenience_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<bool>> response = await client.GetBooleanValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object[]
            {
true
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object[]
            {
true
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new bool[]
            {
true
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new bool[]
            {
true
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object[]
            {
true
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object[]
            {
true
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new bool[]
            {
true
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            BooleanValue client = new ArrayClient().GetBooleanValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new bool[]
            {
true
            });
            Console.WriteLine(response.Status);
        }
    }
}
