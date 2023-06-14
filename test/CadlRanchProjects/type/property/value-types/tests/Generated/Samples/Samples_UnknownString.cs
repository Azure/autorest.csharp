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
    internal class Samples_UnknownString
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownString()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            Response response = client.GetUnknownString(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownString_AllParameters()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            Response response = client.GetUnknownString(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownString_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            Response response = await client.GetUnknownStringAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownString_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            Response response = await client.GetUnknownStringAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownString_Convenience_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var result = await client.GetUnknownStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var data = new
            {
                property = new { },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var data = new
            {
                property = new { },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var data = new
            {
                property = new { },
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var data = new
            {
                property = new { },
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ValueTypesClient().GetUnknownStringClient("1.0.0");

            var body = new UnknownStringProperty(BinaryData.FromString("<your binary data content>"));
            var result = await client.PutAsync(body);
        }
    }
}
