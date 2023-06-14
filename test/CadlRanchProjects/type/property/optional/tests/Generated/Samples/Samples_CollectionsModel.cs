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
using _Type.Property.Optional.Models;

namespace _Type.Property.Optional.Samples
{
    internal class Samples_CollectionsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetAll(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetAll(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetAllAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetAllAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Convenience_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var result = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetDefault(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetDefault(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetDefaultAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetDefaultAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_Convenience_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var result = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new { };

            Response response = client.PutAll(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = client.PutAll(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new { };

            Response response = await client.PutAllAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = await client.PutAllAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Convenience_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var body = new CollectionsModelProperty()
            {
                Property =
{
        new StringProperty()
{
            Property = "<Property>",
        }
    },
            };
            var result = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new { };

            Response response = client.PutDefault(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = client.PutDefault(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new { };

            Response response = await client.PutDefaultAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var data = new
            {
                property = new[] {
        new {
            property = "<property>",
        }
    },
            };

            Response response = await client.PutDefaultAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_Convenience_Async()
        {
            var client = new OptionalClient().GetCollectionsModelClient("1.0.0");

            var body = new CollectionsModelProperty()
            {
                Property =
{
        new StringProperty()
{
            Property = "<Property>",
        }
    },
            };
            var result = await client.PutDefaultAsync(body);
        }
    }
}
