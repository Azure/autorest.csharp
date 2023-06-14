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
    internal class Samples_Boolean
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            Response response = client.GetBoolean(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean_AllParameters()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            Response response = client.GetBoolean(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            Response response = await client.GetBooleanAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            Response response = await client.GetBooleanAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_Convenience_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var result = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var data = new
            {
                property = true,
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var data = new
            {
                property = true,
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var data = new
            {
                property = true,
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var data = new
            {
                property = true,
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ValueTypesClient().GetBooleanClient("1.0.0");

            var body = new BooleanProperty(true);
            var result = await client.PutAsync(body);
        }
    }
}
