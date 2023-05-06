// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace _Type._Array.Samples
{
    internal class Samples_StringValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringValue()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            Response response = client.GetStringValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringValue_AllParameters()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            Response response = client.GetStringValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringValue_Async()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            Response response = await client.GetStringValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringValue_AllParameters_Async()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            Response response = await client.GetStringValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            var data = new[] {
    "<String>"
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            var data = new[] {
    "<String>"
};

            Response response = client.Put(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            var data = new[] {
    "<String>"
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ArrayClient().GetStringValueClient("1.0.0");

            var data = new[] {
    "<String>"
};

            Response response = await client.PutAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }
    }
}
