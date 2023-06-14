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
using _Type._Array.Models;

namespace _Type._Array.Samples
{
    internal class Samples_Int32Value
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInt32Value()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            Response response = client.GetInt32Value(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInt32Value_AllParameters()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            Response response = client.GetInt32Value(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInt32Value_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            Response response = await client.GetInt32ValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInt32Value_AllParameters_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            Response response = await client.GetInt32ValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInt32Value_Convenience_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var result = await client.GetInt32ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var data = new[] {
    1234
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var data = new[] {
    1234
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var data = new[] {
    1234
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var data = new[] {
    1234
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ArrayClient().GetInt32ValueClient("1.0.0");

            var body = new object();
            var result = await client.PutAsync(body);
        }
    }
}
