// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using Encode.Duration;
using Encode.Duration.Models;
using NUnit.Framework;

namespace Encode.Duration.Samples
{
    public partial class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            DefaultDurationProperty body = new DefaultDurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<DefaultDurationProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            DefaultDurationProperty body = new DefaultDurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<DefaultDurationProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            DefaultDurationProperty body = new DefaultDurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<DefaultDurationProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            DefaultDurationProperty body = new DefaultDurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<DefaultDurationProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Iso8601_ShortVersion()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = client.Iso8601(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Iso8601_ShortVersion_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = await client.Iso8601Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Iso8601_ShortVersion_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            ISO8601DurationProperty body = new ISO8601DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<ISO8601DurationProperty> response = client.Iso8601(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Iso8601_ShortVersion_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            ISO8601DurationProperty body = new ISO8601DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<ISO8601DurationProperty> response = await client.Iso8601Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Iso8601_AllParameters()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = client.Iso8601(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Iso8601_AllParameters_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "PT1H23M45S",
            });
            Response response = await client.Iso8601Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Iso8601_AllParameters_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            ISO8601DurationProperty body = new ISO8601DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<ISO8601DurationProperty> response = client.Iso8601(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Iso8601_AllParameters_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            ISO8601DurationProperty body = new ISO8601DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response<ISO8601DurationProperty> response = await client.Iso8601Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Int32Seconds_ShortVersion()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10,
            });
            Response response = client.Int32Seconds(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Int32Seconds_ShortVersion_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10,
            });
            Response response = await client.Int32SecondsAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Int32Seconds_ShortVersion_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            Int32SecondsDurationProperty body = new Int32SecondsDurationProperty(TimeSpan.FromSeconds(10));
            Response<Int32SecondsDurationProperty> response = client.Int32Seconds(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Int32Seconds_ShortVersion_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            Int32SecondsDurationProperty body = new Int32SecondsDurationProperty(TimeSpan.FromSeconds(10));
            Response<Int32SecondsDurationProperty> response = await client.Int32SecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Int32Seconds_AllParameters()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10,
            });
            Response response = client.Int32Seconds(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Int32Seconds_AllParameters_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10,
            });
            Response response = await client.Int32SecondsAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Int32Seconds_AllParameters_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            Int32SecondsDurationProperty body = new Int32SecondsDurationProperty(TimeSpan.FromSeconds(10));
            Response<Int32SecondsDurationProperty> response = client.Int32Seconds(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Int32Seconds_AllParameters_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            Int32SecondsDurationProperty body = new Int32SecondsDurationProperty(TimeSpan.FromSeconds(10));
            Response<Int32SecondsDurationProperty> response = await client.Int32SecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSeconds_ShortVersion()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10F,
            });
            Response response = client.FloatSeconds(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSeconds_ShortVersion_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10F,
            });
            Response response = await client.FloatSecondsAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSeconds_ShortVersion_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationProperty body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(10F));
            Response<FloatSecondsDurationProperty> response = client.FloatSeconds(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSeconds_ShortVersion_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationProperty body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(10F));
            Response<FloatSecondsDurationProperty> response = await client.FloatSecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSeconds_AllParameters()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10F,
            });
            Response response = client.FloatSeconds(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSeconds_AllParameters_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 10F,
            });
            Response response = await client.FloatSecondsAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSeconds_AllParameters_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationProperty body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(10F));
            Response<FloatSecondsDurationProperty> response = client.FloatSeconds(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSeconds_AllParameters_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationProperty body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(10F));
            Response<FloatSecondsDurationProperty> response = await client.FloatSecondsAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSecondsArray_ShortVersion()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
10F
            },
            });
            Response response = client.FloatSecondsArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSecondsArray_ShortVersion_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
10F
            },
            });
            Response response = await client.FloatSecondsArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSecondsArray_ShortVersion_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationArrayProperty body = new FloatSecondsDurationArrayProperty(new TimeSpan[] { TimeSpan.FromSeconds(10F) });
            Response<FloatSecondsDurationArrayProperty> response = client.FloatSecondsArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSecondsArray_ShortVersion_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationArrayProperty body = new FloatSecondsDurationArrayProperty(new TimeSpan[] { TimeSpan.FromSeconds(10F) });
            Response<FloatSecondsDurationArrayProperty> response = await client.FloatSecondsArrayAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSecondsArray_AllParameters()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
10F
            },
            });
            Response response = client.FloatSecondsArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSecondsArray_AllParameters_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
10F
            },
            });
            Response response = await client.FloatSecondsArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_FloatSecondsArray_AllParameters_Convenience()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationArrayProperty body = new FloatSecondsDurationArrayProperty(new TimeSpan[] { TimeSpan.FromSeconds(10F) });
            Response<FloatSecondsDurationArrayProperty> response = client.FloatSecondsArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_FloatSecondsArray_AllParameters_Convenience_Async()
        {
            Property client = new DurationClient().GetPropertyClient();

            FloatSecondsDurationArrayProperty body = new FloatSecondsDurationArrayProperty(new TimeSpan[] { TimeSpan.FromSeconds(10F) });
            Response<FloatSecondsDurationArrayProperty> response = await client.FloatSecondsArrayAsync(body);
        }
    }
}
