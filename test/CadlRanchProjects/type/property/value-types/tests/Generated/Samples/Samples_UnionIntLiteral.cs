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
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public partial class Samples_UnionIntLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_GetUnionIntLiteral_ShortVersion()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response response = client.GetUnionIntLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_GetUnionIntLiteral_ShortVersion_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response response = await client.GetUnionIntLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_GetUnionIntLiteral_ShortVersion_Convenience()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response<UnionIntLiteralProperty> response = client.GetUnionIntLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_GetUnionIntLiteral_ShortVersion_Convenience_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response<UnionIntLiteralProperty> response = await client.GetUnionIntLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_GetUnionIntLiteral_AllParameters()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response response = client.GetUnionIntLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_GetUnionIntLiteral_AllParameters_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response response = await client.GetUnionIntLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_GetUnionIntLiteral_AllParameters_Convenience()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response<UnionIntLiteralProperty> response = client.GetUnionIntLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_GetUnionIntLiteral_AllParameters_Convenience_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            Response<UnionIntLiteralProperty> response = await client.GetUnionIntLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_Put_ShortVersion()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 42,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_Put_ShortVersion_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 42,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_Put_ShortVersion_Convenience()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            UnionIntLiteralProperty body = new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_Put_ShortVersion_Convenience_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            UnionIntLiteralProperty body = new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_Put_AllParameters()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 42,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_Put_AllParameters_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 42,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionIntLiteral_Put_AllParameters_Convenience()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            UnionIntLiteralProperty body = new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionIntLiteral_Put_AllParameters_Convenience_Async()
        {
            UnionIntLiteral client = new ValueTypesClient().GetUnionIntLiteralClient();

            UnionIntLiteralProperty body = new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42);
            Response response = await client.PutAsync(body);
        }
    }
}
