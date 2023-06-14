// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable.Samples
{
    internal class Samples_String
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = client.GetNonNull(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = client.GetNonNull(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = await client.GetNonNullAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = await client.GetNonNullAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_Convenience_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var result = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = client.GetNull(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = client.GetNull(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = await client.GetNullAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            Response response = await client.GetNullAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Convenience_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var result = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = client.PatchNonNull(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_AllParameters()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = client.PatchNonNull(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = await client.PatchNonNullAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_AllParameters_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = await client.PatchNonNullAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = client.PatchNull(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_AllParameters()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = client.PatchNull(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = await client.PatchNullAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_AllParameters_Async()
        {
            var client = new NullableClient().GetStringClient("1.0.0");

            var data = new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "<nullableProperty>",
            };

            Response response = await client.PatchNullAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
