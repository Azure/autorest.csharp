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
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    internal class Samples_Duration
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDuration()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            Response response = client.GetDuration(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDuration_AllParameters()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            Response response = client.GetDuration(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDuration_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            Response response = await client.GetDurationAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDuration_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            Response response = await client.GetDurationAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDuration_Convenience_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var result = await client.GetDurationAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var data = new
            {
                property = "PT1H23M45S",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var data = new
            {
                property = "PT1H23M45S",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var data = new
            {
                property = "PT1H23M45S",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var data = new
            {
                property = "PT1H23M45S",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ValueTypesClient().GetDurationClient("1.0.0");

            var body = new DurationProperty(new TimeSpan(1, 2, 3));
            var result = await client.PutAsync(body);
        }
    }
}
