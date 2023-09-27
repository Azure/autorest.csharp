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
    internal class Samples_Datetime
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_ShortVersion()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_ShortVersion_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_ShortVersion_Convenience()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_ShortVersion_Convenience_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters_Convenience()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Convenience_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_ShortVersion()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_ShortVersion_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_ShortVersion_Convenience()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_ShortVersion_Convenience_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters_Convenience()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Convenience_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_ShortVersion()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PatchNonNull(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_ShortVersion_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PatchNonNullAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_AllParameters()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PatchNonNull(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_AllParameters_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PatchNonNullAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_ShortVersion()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PatchNull(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_ShortVersion_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PatchNullAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_AllParameters()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PatchNull(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_AllParameters_Async()
        {
            Datetime client = new NullableClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PatchNullAsync(content);
            Console.WriteLine(response.Status);
        }
    }
}
