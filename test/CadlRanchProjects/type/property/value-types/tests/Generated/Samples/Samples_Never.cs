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
    public partial class Samples_Never
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNever_ShortVersion()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response response = client.GetNever(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNever_ShortVersion_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response response = await client.GetNeverAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNever_ShortVersion_Convenience()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = client.GetNever();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNever_ShortVersion_Convenience_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = await client.GetNeverAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNever_AllParameters()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response response = client.GetNever(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNever_AllParameters_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response response = await client.GetNeverAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNever_AllParameters_Convenience()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = client.GetNever();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNever_AllParameters_Convenience_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = await client.GetNeverAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Never client = new ValueTypesClient().GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = await client.PutAsync(body);
        }
    }
}
