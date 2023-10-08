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
using _Type.Property.Nullable;
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable.Samples
{
    public partial class Samples_CollectionsByte
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_ShortVersion()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_ShortVersion_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_ShortVersion_Convenience()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters_Convenience()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_ShortVersion()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_ShortVersion_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_ShortVersion_Convenience()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters_Convenience()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_ShortVersion()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_ShortVersion_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_AllParameters()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_AllParameters_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_ShortVersion()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_ShortVersion_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_AllParameters()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_AllParameters_Async()
        {
            CollectionsByte client = new NullableClient().GetCollectionsByteClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new object()
            },
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
