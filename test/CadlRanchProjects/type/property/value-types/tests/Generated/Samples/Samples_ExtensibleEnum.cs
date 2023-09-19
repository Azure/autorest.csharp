// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public class Samples_ExtensibleEnum
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleEnum()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = client.GetExtensibleEnum(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleEnum_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleEnum_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = client.GetExtensibleEnum();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleEnum_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleEnum_AllParameters()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = client.GetExtensibleEnum(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleEnum_AllParameters_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleEnum_AllParameters_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = client.GetExtensibleEnum();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleEnum_AllParameters_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
