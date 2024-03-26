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
    public partial class Samples_Decimal128
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_GetDecimal128_ShortVersion()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response response = client.GetDecimal128(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_GetDecimal128_ShortVersion_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response response = await client.GetDecimal128Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_GetDecimal128_ShortVersion_Convenience()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response<Decimal128Property> response = client.GetDecimal128();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_GetDecimal128_ShortVersion_Convenience_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response<Decimal128Property> response = await client.GetDecimal128Async();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_GetDecimal128_AllParameters()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response response = client.GetDecimal128(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_GetDecimal128_AllParameters_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response response = await client.GetDecimal128Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_GetDecimal128_AllParameters_Convenience()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response<Decimal128Property> response = client.GetDecimal128();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_GetDecimal128_AllParameters_Convenience_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Response<Decimal128Property> response = await client.GetDecimal128Async();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_Put_ShortVersion()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_Put_ShortVersion_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_Put_ShortVersion_Convenience()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Decimal128Property body = new Decimal128Property(default);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_Put_ShortVersion_Convenience_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Decimal128Property body = new Decimal128Property(default);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_Put_AllParameters()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_Put_AllParameters_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128_Put_AllParameters_Convenience()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Decimal128Property body = new Decimal128Property(default);
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128_Put_AllParameters_Convenience_Async()
        {
            Decimal128 client = new ValueTypesClient().GetDecimal128Client();

            Decimal128Property body = new Decimal128Property(default);
            Response response = await client.PutAsync(body);
        }
    }
}
