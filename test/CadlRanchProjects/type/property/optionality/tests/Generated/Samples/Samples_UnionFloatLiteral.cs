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
    public partial class Samples_UnionFloatLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetAll_ShortVersion()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetAll_ShortVersion_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetAll_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetAll_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetAll_AllParameters()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetAll_AllParameters_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetAll_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetAll_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetDefault_ShortVersion()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetDefault_ShortVersion_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetDefault_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetDefault_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetDefault_AllParameters()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetDefault_AllParameters_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetDefault_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetDefault_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutAll_ShortVersion()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutAll_ShortVersion_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutAll_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutAll_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutAll_AllParameters()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1.25F,
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutAll_AllParameters_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1.25F,
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutAll_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty
            {
                Property = UnionFloatLiteralPropertyProperty._125,
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutAll_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty
            {
                Property = UnionFloatLiteralPropertyProperty._125,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutDefault_ShortVersion()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutDefault_ShortVersion_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutDefault_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutDefault_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutDefault_AllParameters()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1.25F,
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutDefault_AllParameters_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1.25F,
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_PutDefault_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty
            {
                Property = UnionFloatLiteralPropertyProperty._125,
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_PutDefault_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new OptionalClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty
            {
                Property = UnionFloatLiteralPropertyProperty._125,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
