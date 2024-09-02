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
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable.Samples
{
    public partial class Samples_Bytes
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNonNull_ShortVersion()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNonNull_ShortVersion_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNonNull_ShortVersion_Convenience()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNonNull_ShortVersion_Convenience_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNonNull_AllParameters()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNonNull_AllParameters_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNonNull_AllParameters_Convenience()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNonNull_AllParameters_Convenience_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNull_ShortVersion()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNull_ShortVersion_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNull_ShortVersion_Convenience()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNull_ShortVersion_Convenience_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNull_AllParameters()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNull_AllParameters_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetNull_AllParameters_Convenience()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetNull_AllParameters_Convenience_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_PatchNonNull_ShortVersion()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_PatchNonNull_ShortVersion_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_PatchNonNull_AllParameters()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_PatchNonNull_AllParameters_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_PatchNull_ShortVersion()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_PatchNull_ShortVersion_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_PatchNull_AllParameters()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_PatchNull_AllParameters_Async()
        {
            Bytes client = new NullableClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
