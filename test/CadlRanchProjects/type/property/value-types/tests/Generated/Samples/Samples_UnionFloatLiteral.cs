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
    public partial class Samples_UnionFloatLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetUnionFloatLiteral_ShortVersion()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response response = client.GetUnionFloatLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetUnionFloatLiteral_ShortVersion_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response response = await client.GetUnionFloatLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetUnionFloatLiteral_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetUnionFloatLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetUnionFloatLiteral_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetUnionFloatLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetUnionFloatLiteral_AllParameters()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response response = client.GetUnionFloatLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetUnionFloatLiteral_AllParameters_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response response = await client.GetUnionFloatLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_GetUnionFloatLiteral_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = client.GetUnionFloatLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_GetUnionFloatLiteral_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            Response<UnionFloatLiteralProperty> response = await client.GetUnionFloatLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_Put_ShortVersion()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 43.125,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_Put_ShortVersion_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 43.125,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_Put_ShortVersion_Convenience()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty(BinaryData.FromObjectAsJson(43.125));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_Put_ShortVersion_Convenience_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty(BinaryData.FromObjectAsJson(43.125));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_Put_AllParameters()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 43.125,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_Put_AllParameters_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 43.125,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnionFloatLiteral_Put_AllParameters_Convenience()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty(BinaryData.FromObjectAsJson(43.125));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnionFloatLiteral_Put_AllParameters_Convenience_Async()
        {
            UnionFloatLiteral client = new ValueTypesClient().GetUnionFloatLiteralClient();

            UnionFloatLiteralProperty body = new UnionFloatLiteralProperty(BinaryData.FromObjectAsJson(43.125));
            Response response = await client.PutAsync(body);
        }
    }
}
