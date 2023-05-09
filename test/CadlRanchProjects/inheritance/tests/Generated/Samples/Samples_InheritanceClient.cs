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
using _Type.Model.Inheritance.Models;

namespace _Type.Model.Inheritance.Samples
{
    public class Samples_InheritanceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostValid()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = client.PostValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostValid_AllParameters()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = client.PostValid(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostValid_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = await client.PostValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostValid_AllParameters_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = await client.PostValidAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostValid_Convenience_Async()
        {
            var client = new InheritanceClient();

            var input = new Siamese("<name>", 1234, true);
            var result = await client.PostValidAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            var client = new InheritanceClient();

            Response response = client.GetValid(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            var client = new InheritanceClient();

            Response response = client.GetValid(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetValidAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetValidAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Convenience_Async()
        {
            var client = new InheritanceClient();

            var result = await client.GetValidAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = client.PutValid(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid_AllParameters()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = client.PutValid(RequestContent.Create(data), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_AllParameters_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                smart = true,
                age = 1234,
                name = "<name>",
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("smart").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Convenience_Async()
        {
            var client = new InheritanceClient();

            var input = new Siamese("<name>", 1234, true);
            var result = await client.PutValidAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel()
        {
            var client = new InheritanceClient();

            Response response = client.GetModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters()
        {
            var client = new InheritanceClient();

            Response response = client.GetModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Convenience_Async()
        {
            var client = new InheritanceClient();

            var result = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = client.PutModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutModel_AllParameters()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = client.PutModel(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = await client.PutModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_AllParameters_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = await client.PutModelAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutModel_Convenience_Async()
        {
            var client = new InheritanceClient();

            var input = new Shark(1234);
            var result = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel()
        {
            var client = new InheritanceClient();

            Response response = client.GetRecursiveModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRecursiveModel_AllParameters()
        {
            var client = new InheritanceClient();

            Response response = client.GetRecursiveModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetRecursiveModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_AllParameters_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetRecursiveModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRecursiveModel_Convenience_Async()
        {
            var client = new InheritanceClient();

            var result = await client.GetRecursiveModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = client.PutRecursiveModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRecursiveModel_AllParameters()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = client.PutRecursiveModel(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = await client.PutRecursiveModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_AllParameters_Async()
        {
            var client = new InheritanceClient();

            var data = new
            {
                age = 1234,
            };

            Response response = await client.PutRecursiveModelAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRecursiveModel_Convenience_Async()
        {
            var client = new InheritanceClient();

            var input = new Shark(1234);
            var result = await client.PutRecursiveModelAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator()
        {
            var client = new InheritanceClient();

            Response response = client.GetMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMissingDiscriminator_AllParameters()
        {
            var client = new InheritanceClient();

            Response response = client.GetMissingDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_AllParameters_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetMissingDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMissingDiscriminator_Convenience_Async()
        {
            var client = new InheritanceClient();

            var result = await client.GetMissingDiscriminatorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator()
        {
            var client = new InheritanceClient();

            Response response = client.GetWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWrongDiscriminator_AllParameters()
        {
            var client = new InheritanceClient();

            Response response = client.GetWrongDiscriminator(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_AllParameters_Async()
        {
            var client = new InheritanceClient();

            Response response = await client.GetWrongDiscriminatorAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWrongDiscriminator_Convenience_Async()
        {
            var client = new InheritanceClient();

            var result = await client.GetWrongDiscriminatorAsync();
        }
    }
}
