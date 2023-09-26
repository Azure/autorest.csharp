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
    public class Samples_String
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.GetString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_Convenience()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = client.GetString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_Convenience_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.GetString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters_Convenience()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = client.GetString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Convenience_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty("<property>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty("<property>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty("<property>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            String client = new ValueTypesClient().GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty("<property>");
            Response response = await client.PutAsync(body);
        }
    }
}
