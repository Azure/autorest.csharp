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
    public partial class Samples_Duration
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNonNull_ShortVersion()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNonNull_ShortVersion_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNonNull_ShortVersion_Convenience()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNonNull_ShortVersion_Convenience_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNonNull_AllParameters()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = client.GetNonNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNonNull_AllParameters_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = await client.GetNonNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNonNull_AllParameters_Convenience()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNonNull_AllParameters_Convenience_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNull_ShortVersion()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNull_ShortVersion_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNull_ShortVersion_Convenience()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNull_ShortVersion_Convenience_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNull_AllParameters()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNull_AllParameters_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
            Console.WriteLine(result.GetProperty("nullableProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetNull_AllParameters_Convenience()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetNull_AllParameters_Convenience_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_PatchNonNull_ShortVersion()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_PatchNonNull_ShortVersion_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_PatchNonNull_AllParameters()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = client.PatchNonNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_PatchNonNull_AllParameters_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = await client.PatchNonNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_PatchNull_ShortVersion()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_PatchNull_ShortVersion_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_PatchNull_AllParameters()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = client.PatchNull(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_PatchNull_AllParameters_Async()
        {
            Duration client = new NullableClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = "PT1H23M45S",
            });
            Response response = await client.PatchNullAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
