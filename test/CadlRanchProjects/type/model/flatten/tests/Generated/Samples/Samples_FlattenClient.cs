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
using _Type.Model.Flatten.Models;

namespace _Type.Model.Flatten.Samples
{
    public partial class Samples_FlattenClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutFlattenModel_ShortVersion()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = client.PutFlattenModel(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutFlattenModel_ShortVersion_Async()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutFlattenModelAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutFlattenModel_ShortVersion_Convenience()
        {
            FlattenClient client = new FlattenClient();

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = client.PutFlattenModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutFlattenModel_ShortVersion_Convenience_Async()
        {
            FlattenClient client = new FlattenClient();

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = await client.PutFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutFlattenModel_AllParameters()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = client.PutFlattenModel(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutFlattenModel_AllParameters_Async()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutFlattenModelAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutFlattenModel_AllParameters_Convenience()
        {
            FlattenClient client = new FlattenClient();

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = client.PutFlattenModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutFlattenModel_AllParameters_Convenience_Async()
        {
            FlattenClient client = new FlattenClient();

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = await client.PutFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutNestedFlattenModel_ShortVersion()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = client.PutNestedFlattenModel(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("summary").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutNestedFlattenModel_ShortVersion_Async()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutNestedFlattenModelAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("summary").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutNestedFlattenModel_ShortVersion_Convenience()
        {
            FlattenClient client = new FlattenClient();

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = client.PutNestedFlattenModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutNestedFlattenModel_ShortVersion_Convenience_Async()
        {
            FlattenClient client = new FlattenClient();

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = await client.PutNestedFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutNestedFlattenModel_AllParameters()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = client.PutNestedFlattenModel(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("summary").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutNestedFlattenModel_AllParameters_Async()
        {
            FlattenClient client = new FlattenClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutNestedFlattenModelAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("summary").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Flatten_PutNestedFlattenModel_AllParameters_Convenience()
        {
            FlattenClient client = new FlattenClient();

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = client.PutNestedFlattenModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Flatten_PutNestedFlattenModel_AllParameters_Convenience_Async()
        {
            FlattenClient client = new FlattenClient();

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = await client.PutNestedFlattenModelAsync(input);
        }
    }
}
