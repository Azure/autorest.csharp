// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using NUnit.Framework;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    internal class Samples_CollectionsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetCollectionsModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel_AllParameters()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetCollectionsModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetCollectionsModelAsync(new RequestContext()).ConfigureAwait(false);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetCollectionsModelAsync(new RequestContext()).ConfigureAwait(false);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_Convenience_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var result = await client.GetCollectionsModelAsync().ConfigureAwait(false);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = await client.PutAsync(RequestContent.Create(data)).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = await client.PutAsync(RequestContent.Create(data)).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            var body = new CollectionsModelProperty(new InnerModel[]
            {
    new InnerModel("<property>")
            });
            var result = await client.PutAsync(body).ConfigureAwait(false);
        }
    }
}
