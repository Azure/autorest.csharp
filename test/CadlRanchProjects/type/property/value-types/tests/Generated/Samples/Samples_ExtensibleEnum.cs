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
    public partial class Samples_ExtensibleEnum
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_GetExtensibleEnum_ShortVersion()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response response = client.GetExtensibleEnum(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_GetExtensibleEnum_ShortVersion_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_GetExtensibleEnum_ShortVersion_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response<ExtensibleEnumProperty> response = client.GetExtensibleEnum();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_GetExtensibleEnum_ShortVersion_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_GetExtensibleEnum_AllParameters()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response response = client.GetExtensibleEnum(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_GetExtensibleEnum_AllParameters_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_GetExtensibleEnum_AllParameters_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response<ExtensibleEnumProperty> response = client.GetExtensibleEnum();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_GetExtensibleEnum_AllParameters_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_Put_ShortVersion()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_Put_ShortVersion_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_Put_ShortVersion_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_Put_ShortVersion_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_Put_AllParameters()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_Put_AllParameters_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtensibleEnum_Put_AllParameters_Convenience()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtensibleEnum_Put_AllParameters_Convenience_Async()
        {
            ExtensibleEnum client = new ValueTypesClient().GetExtensibleEnumClient();

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
        }
    }
}
