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
using _Type.Model.Inheritance.SingleDiscriminator.Models;

namespace _Type.Model.Inheritance.SingleDiscriminator.Samples
{
    public partial class Samples_SingleDiscriminatorClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetModel_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetModel_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetModel_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetModel_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutModel_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutModel_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutModel_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutModel_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetRecursiveModel_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetRecursiveModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetRecursiveModel_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetRecursiveModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetRecursiveModel_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetRecursiveModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetRecursiveModel_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetRecursiveModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetRecursiveModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetRecursiveModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetRecursiveModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetRecursiveModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetRecursiveModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetRecursiveModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetRecursiveModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetRecursiveModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutRecursiveModel_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutRecursiveModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutRecursiveModel_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutRecursiveModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutRecursiveModel_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutRecursiveModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutRecursiveModel_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutRecursiveModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutRecursiveModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutRecursiveModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutRecursiveModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutRecursiveModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_PutRecursiveModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutRecursiveModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_PutRecursiveModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutRecursiveModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetMissingDiscriminator_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetMissingDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetMissingDiscriminator_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetMissingDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetMissingDiscriminator_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetMissingDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetMissingDiscriminator_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetMissingDiscriminator_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetMissingDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetMissingDiscriminator_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetMissingDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetMissingDiscriminator_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetMissingDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetMissingDiscriminator_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetWrongDiscriminator_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetWrongDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetWrongDiscriminator_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetWrongDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetWrongDiscriminator_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetWrongDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetWrongDiscriminator_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetWrongDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetWrongDiscriminator_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetWrongDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetWrongDiscriminator_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetWrongDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetWrongDiscriminator_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetWrongDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetWrongDiscriminator_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetWrongDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetLegacyModel_ShortVersion()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetLegacyModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetLegacyModel_ShortVersion_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetLegacyModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetLegacyModel_ShortVersion_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = client.GetLegacyModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetLegacyModel_ShortVersion_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = await client.GetLegacyModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetLegacyModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetLegacyModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetLegacyModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetLegacyModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SingleDiscriminator_GetLegacyModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = client.GetLegacyModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SingleDiscriminator_GetLegacyModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = await client.GetLegacyModelAsync();
        }
    }
}
