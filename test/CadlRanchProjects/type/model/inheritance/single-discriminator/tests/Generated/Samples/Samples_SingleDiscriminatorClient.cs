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
using _Type.Model.Inheritance.SingleDiscriminator;
using _Type.Model.Inheritance.SingleDiscriminator.Models;

namespace _Type.Model.Inheritance.SingleDiscriminator.Samples
{
    public partial class Samples_SingleDiscriminatorClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetRecursiveModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetRecursiveModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetRecursiveModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetRecursiveModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetRecursiveModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetRecursiveModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetRecursiveModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetRecursiveModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutRecursiveModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutRecursiveModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutRecursiveModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutRecursiveModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = client.PutRecursiveModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            RequestContent content = RequestContent.Create(new
            {
                kind = "seagull",
                wingspan = 1234,
            });
            Response response = await client.PutRecursiveModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = client.PutRecursiveModel(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Bird input = new SeaGull(1234);
            Response response = await client.PutRecursiveModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetMissingDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetMissingDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetMissingDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetMissingDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetMissingDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetMissingDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetWrongDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetWrongDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetWrongDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetWrongDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetWrongDiscriminator(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetWrongDiscriminatorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("wingspan").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = client.GetWrongDiscriminator();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Bird> response = await client.GetWrongDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLegacyModel()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetLegacyModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLegacyModel_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetLegacyModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLegacyModel_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = client.GetLegacyModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLegacyModel_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = await client.GetLegacyModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLegacyModel_AllParameters()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = client.GetLegacyModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLegacyModel_AllParameters_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response response = await client.GetLegacyModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLegacyModel_AllParameters_Convenience()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = client.GetLegacyModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLegacyModel_AllParameters_Convenience_Async()
        {
            SingleDiscriminatorClient client = new SingleDiscriminatorClient();

            Response<Dinosaur> response = await client.GetLegacyModelAsync();
        }
    }
}
