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
    internal class Samples_Enum
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnum()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            Response response = client.GetEnum(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnum_AllParameters()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            Response response = client.GetEnum(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnum_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            Response response = await client.GetEnumAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnum_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            Response response = await client.GetEnumAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnum_Convenience_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var result = await client.GetEnumAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var data = new
            {
                property = "ValueOne",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var data = new
            {
                property = "ValueOne",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var data = new
            {
                property = "ValueOne",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var data = new
            {
                property = "ValueOne",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ValueTypesClient().GetEnumClient("1.0.0");

            var body = new EnumProperty(FixedInnerEnum.ValueOne);
            var result = await client.PutAsync(body);
        }
    }
}
