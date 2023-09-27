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
    internal class Samples_UnknownArray
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownArray_ShortVersion()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownArray_ShortVersion_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownArray_ShortVersion_Convenience()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response<UnknownArrayProperty> response = client.GetUnknownArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownArray_ShortVersion_Convenience_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response<UnknownArrayProperty> response = await client.GetUnknownArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownArray_AllParameters()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownArray_AllParameters_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownArray_AllParameters_Convenience()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response<UnknownArrayProperty> response = client.GetUnknownArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownArray_AllParameters_Convenience_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            Response<UnknownArrayProperty> response = await client.GetUnknownArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            UnknownArray client = new ValueTypesClient().GetUnknownArrayClient(apiVersion: "1.0.0");

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
