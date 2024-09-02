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
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public partial class Samples_IntLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetAll_ShortVersion()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetAll_ShortVersion_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetAll_ShortVersion_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetAll_ShortVersion_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetAll_AllParameters()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetAll_AllParameters_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetAll_AllParameters_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetAll_AllParameters_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetDefault_ShortVersion()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetDefault_ShortVersion_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetDefault_ShortVersion_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetDefault_ShortVersion_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetDefault_AllParameters()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetDefault_AllParameters_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_GetDefault_AllParameters_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_GetDefault_AllParameters_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutAll_ShortVersion()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutAll_ShortVersion_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutAll_ShortVersion_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutAll_ShortVersion_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutAll_AllParameters()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutAll_AllParameters_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutAll_AllParameters_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutAll_AllParameters_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutDefault_ShortVersion()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutDefault_ShortVersion_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutDefault_ShortVersion_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutDefault_ShortVersion_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutDefault_AllParameters()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutDefault_AllParameters_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntLiteral_PutDefault_AllParameters_Convenience()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntLiteral_PutDefault_AllParameters_Convenience_Async()
        {
            IntLiteral client = new OptionalClient().GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
