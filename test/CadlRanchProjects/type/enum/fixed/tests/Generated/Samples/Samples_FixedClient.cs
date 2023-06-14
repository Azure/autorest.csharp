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
using _Type._Enum.Fixed.Models;

namespace _Type._Enum.Fixed.Samples
{
    public class Samples_FixedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue()
        {
            var client = new FixedClient();

            Response response = client.GetKnownValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_AllParameters()
        {
            var client = new FixedClient();

            Response response = client.GetKnownValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_Async()
        {
            var client = new FixedClient();

            Response response = await client.GetKnownValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_AllParameters_Async()
        {
            var client = new FixedClient();

            Response response = await client.GetKnownValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_Convenience_Async()
        {
            var client = new FixedClient();

            var result = await client.GetKnownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutKnownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_AllParameters()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutKnownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_Async()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = await client.PutKnownValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_AllParameters_Async()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = await client.PutKnownValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_Convenience_Async()
        {
            var client = new FixedClient();

            var body = DaysOfWeekEnum.Monday;
            var result = await client.PutKnownValueAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutUnknownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_AllParameters()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutUnknownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_Async()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = await client.PutUnknownValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_AllParameters_Async()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = await client.PutUnknownValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_Convenience_Async()
        {
            var client = new FixedClient();

            var body = DaysOfWeekEnum.Monday;
            var result = await client.PutUnknownValueAsync(body);
        }
    }
}
