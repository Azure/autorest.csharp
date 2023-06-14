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
    internal class Samples_DurationValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValue()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            Response response = client.GetDurationValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValue_AllParameters()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            Response response = client.GetDurationValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            Response response = await client.GetDurationValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_AllParameters_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            Response response = await client.GetDurationValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_Convenience_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var result = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var data = new[] {
    "PT1H23M45S"
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var data = new[] {
    "PT1H23M45S"
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var data = new[] {
    "PT1H23M45S"
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var data = new[] {
    "PT1H23M45S"
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ArrayClient().GetDurationValueClient("1.0.0");

            var body = new object();
            var result = await client.PutAsync(body);
        }
    }
}
