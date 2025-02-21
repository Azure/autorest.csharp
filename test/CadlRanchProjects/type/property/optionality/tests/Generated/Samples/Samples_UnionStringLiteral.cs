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
    public partial class Samples_UnionStringLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetAll_ShortVersion()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetAll_ShortVersion_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetAll_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetAll_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetAll_AllParameters()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetAll_AllParameters_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetAll_AllParameters_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetAll_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetDefault_ShortVersion()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetDefault_ShortVersion_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetDefault_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetDefault_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetDefault_AllParameters()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetDefault_AllParameters_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetDefault_AllParameters_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetDefault_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutAll_ShortVersion()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutAll_ShortVersion_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutAll_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutAll_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutAll_AllParameters()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutAll_AllParameters_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutAll_AllParameters_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty
            {
                Property = UnionStringLiteralPropertyProperty.Hello,
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutAll_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty
            {
                Property = UnionStringLiteralPropertyProperty.Hello,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutDefault_ShortVersion()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutDefault_ShortVersion_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutDefault_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutDefault_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutDefault_AllParameters()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutDefault_AllParameters_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_PutDefault_AllParameters_Convenience()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty
            {
                Property = UnionStringLiteralPropertyProperty.Hello,
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_PutDefault_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new OptionalClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty
            {
                Property = UnionStringLiteralPropertyProperty.Hello,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
