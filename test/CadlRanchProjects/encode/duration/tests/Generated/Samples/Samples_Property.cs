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
using Encode.Duration.Models;
using NUnit.Framework;

namespace Encode.Duration.Samples
{
    internal class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = client.Default(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = client.Default(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = await client.DefaultAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = await client.DefaultAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Convenience_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var body = new DefaultDurationProperty(new TimeSpan(1, 2, 3));
            var result = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Iso8601()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = client.Iso8601(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Iso8601_AllParameters()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = client.Iso8601(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Iso8601_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = await client.Iso8601Async(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Iso8601_AllParameters_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = "PT1H23M45S",
            };

            Response response = await client.Iso8601Async(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Iso8601_Convenience_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var body = new ISO8601DurationProperty(new TimeSpan(1, 2, 3));
            var result = await client.Iso8601Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32Seconds()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = client.Int32Seconds(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32Seconds_AllParameters()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = client.Int32Seconds(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32Seconds_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = await client.Int32SecondsAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32Seconds_AllParameters_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = await client.Int32SecondsAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32Seconds_Convenience_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var body = new Int32SecondsDurationProperty(new TimeSpan(1, 2, 3));
            var result = await client.Int32SecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSeconds()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = client.FloatSeconds(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSeconds_AllParameters()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = client.FloatSeconds(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSeconds_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = await client.FloatSecondsAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSeconds_AllParameters_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new { },
            };

            Response response = await client.FloatSecondsAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSeconds_Convenience_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var body = new FloatSecondsDurationProperty(new TimeSpan(1, 2, 3));
            var result = await client.FloatSecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSecondsArray()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new[] {
        new {}
    },
            };

            Response response = client.FloatSecondsArray(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSecondsArray_AllParameters()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new[] {
        new {}
    },
            };

            Response response = client.FloatSecondsArray(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSecondsArray_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new[] {
        new {}
    },
            };

            Response response = await client.FloatSecondsArrayAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSecondsArray_AllParameters_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var data = new
            {
                value = new[] {
        new {}
    },
            };

            Response response = await client.FloatSecondsArrayAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSecondsArray_Convenience_Async()
        {
            var client = new DurationClient().GetPropertyClient("1.0.0");

            var body = new FloatSecondsDurationArrayProperty(new TimeSpan[]
            {
    new TimeSpan(1, 2, 3)
            });
            var result = await client.FloatSecondsArrayAsync(body);
        }
    }
}
