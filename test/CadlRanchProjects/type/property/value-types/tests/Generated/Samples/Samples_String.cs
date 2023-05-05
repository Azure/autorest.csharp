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

namespace _Type.Property.ValueTypes.Samples
{
    internal class Samples_String
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            Response response = client.GetString(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            Response response = client.GetString(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_Async()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            Response response = await client.GetStringAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            Response response = await client.GetStringAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            var data = new
            {
                property = "<property>",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            var data = new
            {
                property = "<property>",
            };

            Response response = client.Put(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            var data = new
            {
                property = "<property>",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetStringClient("1.0.0");

            var data = new
            {
                property = "<property>",
            };

            Response response = await client.PutAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }
    }
}
