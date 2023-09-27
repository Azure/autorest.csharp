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
    public partial class Samples_UnknownInt
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownInt()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownInt(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownInt_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownIntAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownInt_Convenience()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response<UnknownIntProperty> response = client.GetUnknownInt();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownInt_Convenience_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response<UnknownIntProperty> response = await client.GetUnknownIntAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownInt_AllParameters()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownInt(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownInt_AllParameters_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownIntAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownInt_AllParameters_Convenience()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response<UnknownIntProperty> response = client.GetUnknownInt();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownInt_AllParameters_Convenience_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            Response<UnknownIntProperty> response = await client.GetUnknownIntAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            UnknownIntProperty body = new UnknownIntProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            UnknownIntProperty body = new UnknownIntProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

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
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

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
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            UnknownIntProperty body = new UnknownIntProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            UnknownInt client = new ValueTypesClient().GetUnknownIntClient(apiVersion: "1.0.0");

            UnknownIntProperty body = new UnknownIntProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
