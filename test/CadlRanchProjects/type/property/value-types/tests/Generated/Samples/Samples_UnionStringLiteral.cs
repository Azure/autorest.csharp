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
    public partial class Samples_UnionStringLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetUnionStringLiteral_ShortVersion()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response response = client.GetUnionStringLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetUnionStringLiteral_ShortVersion_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response response = await client.GetUnionStringLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetUnionStringLiteral_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetUnionStringLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetUnionStringLiteral_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetUnionStringLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetUnionStringLiteral_AllParameters()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response response = client.GetUnionStringLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetUnionStringLiteral_AllParameters_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response response = await client.GetUnionStringLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_GetUnionStringLiteral_AllParameters_Convenience()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = client.GetUnionStringLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_GetUnionStringLiteral_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetUnionStringLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_Put_ShortVersion()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_Put_ShortVersion_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_Put_ShortVersion_Convenience()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_Put_ShortVersion_Convenience_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_Put_AllParameters()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_Put_AllParameters_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionStringLiteral_Put_AllParameters_Convenience()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionStringLiteral_Put_AllParameters_Convenience_Async()
        {
            UnionStringLiteral client = new ValueTypesClient().GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = await client.PutAsync(body);
        }
    }
}
