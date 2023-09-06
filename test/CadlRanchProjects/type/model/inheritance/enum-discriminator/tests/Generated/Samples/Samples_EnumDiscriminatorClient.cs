// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
using _Type.Model.Inheritance.EnumDiscriminator.Models;

namespace _Type.Model.Inheritance.EnumDiscriminator.Samples
{
    public class Samples_EnumDiscriminatorClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModel()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModel_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModel_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModel_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModel_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetExtensibleModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutExtensibleModel()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "golden",
                weight = 1234,
            };

            Response response = client.PutExtensibleModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutExtensibleModel_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "golden",
                weight = 1234,
            };

            Response response = client.PutExtensibleModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutExtensibleModel_Async()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "golden",
                weight = 1234,
            };

            Response response = await client.PutExtensibleModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutExtensibleModel_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "golden",
                weight = 1234,
            };

            Response response = await client.PutExtensibleModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutExtensibleModel_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var input = new Golden(1234);
            var result = await client.PutExtensibleModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModelMissingDiscriminator()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModelMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModelMissingDiscriminator_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModelMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelMissingDiscriminator_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelMissingDiscriminator_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelMissingDiscriminator_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetExtensibleModelMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModelWrongDiscriminator()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModelWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetExtensibleModelWrongDiscriminator_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetExtensibleModelWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelWrongDiscriminator_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelWrongDiscriminator_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetExtensibleModelWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("weight").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetExtensibleModelWrongDiscriminator_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetExtensibleModelWrongDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModel()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModel_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModel_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModel_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModel_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetFixedModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFixedModel()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "cobra",
                length = 1234,
            };

            Response response = client.PutFixedModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFixedModel_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "cobra",
                length = 1234,
            };

            Response response = client.PutFixedModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFixedModel_Async()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "cobra",
                length = 1234,
            };

            Response response = await client.PutFixedModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFixedModel_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            var data = new
            {
                kind = "cobra",
                length = 1234,
            };

            Response response = await client.PutFixedModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFixedModel_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var input = new Cobra(1234);
            var result = await client.PutFixedModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModelMissingDiscriminator()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModelMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModelMissingDiscriminator_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModelMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelMissingDiscriminator_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelMissingDiscriminator_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelMissingDiscriminator_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetFixedModelMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModelWrongDiscriminator()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModelWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFixedModelWrongDiscriminator_AllParameters()
        {
            var client = new EnumDiscriminatorClient();

            Response response = client.GetFixedModelWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelWrongDiscriminator_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelWrongDiscriminator_AllParameters_Async()
        {
            var client = new EnumDiscriminatorClient();

            Response response = await client.GetFixedModelWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFixedModelWrongDiscriminator_Convenience_Async()
        {
            var client = new EnumDiscriminatorClient();

            var result = await client.GetFixedModelWrongDiscriminatorAsync();
        }
    }
}
