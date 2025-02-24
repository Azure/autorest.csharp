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
using Encode.Datetime.Models;
using NUnit.Framework;

namespace Encode.Datetime.Samples
{
    public partial class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            DefaultDatetimeProperty body = new DefaultDatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<DefaultDatetimeProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            DefaultDatetimeProperty body = new DefaultDatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<DefaultDatetimeProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            DefaultDatetimeProperty body = new DefaultDatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<DefaultDatetimeProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            DefaultDatetimeProperty body = new DefaultDatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<DefaultDatetimeProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc3339_ShortVersion()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = client.Rfc3339(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc3339_ShortVersion_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = await client.Rfc3339Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc3339_ShortVersion_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc3339DatetimeProperty body = new Rfc3339DatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<Rfc3339DatetimeProperty> response = client.Rfc3339(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc3339_ShortVersion_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc3339DatetimeProperty body = new Rfc3339DatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<Rfc3339DatetimeProperty> response = await client.Rfc3339Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc3339_AllParameters()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = client.Rfc3339(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc3339_AllParameters_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = await client.Rfc3339Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc3339_AllParameters_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc3339DatetimeProperty body = new Rfc3339DatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<Rfc3339DatetimeProperty> response = client.Rfc3339(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc3339_AllParameters_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc3339DatetimeProperty body = new Rfc3339DatetimeProperty(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Response<Rfc3339DatetimeProperty> response = await client.Rfc3339Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc7231_ShortVersion()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "Tue, 10 May 2022 18:57:31 GMT",
            });
            Response response = client.Rfc7231(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc7231_ShortVersion_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "Tue, 10 May 2022 18:57:31 GMT",
            });
            Response response = await client.Rfc7231Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc7231_ShortVersion_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc7231DatetimeProperty body = new Rfc7231DatetimeProperty(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Response<Rfc7231DatetimeProperty> response = client.Rfc7231(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc7231_ShortVersion_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc7231DatetimeProperty body = new Rfc7231DatetimeProperty(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Response<Rfc7231DatetimeProperty> response = await client.Rfc7231Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc7231_AllParameters()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "Tue, 10 May 2022 18:57:31 GMT",
            });
            Response response = client.Rfc7231(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc7231_AllParameters_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = "Tue, 10 May 2022 18:57:31 GMT",
            });
            Response response = await client.Rfc7231Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Rfc7231_AllParameters_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc7231DatetimeProperty body = new Rfc7231DatetimeProperty(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Response<Rfc7231DatetimeProperty> response = client.Rfc7231(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Rfc7231_AllParameters_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            Rfc7231DatetimeProperty body = new Rfc7231DatetimeProperty(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Response<Rfc7231DatetimeProperty> response = await client.Rfc7231Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestamp_ShortVersion()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1652209051,
            });
            Response response = client.UnixTimestamp(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestamp_ShortVersion_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1652209051,
            });
            Response response = await client.UnixTimestampAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestamp_ShortVersion_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampDatetimeProperty body = new UnixTimestampDatetimeProperty(DateTimeOffset.FromUnixTimeSeconds(1652209051L));
            Response<UnixTimestampDatetimeProperty> response = client.UnixTimestamp(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestamp_ShortVersion_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampDatetimeProperty body = new UnixTimestampDatetimeProperty(DateTimeOffset.FromUnixTimeSeconds(1652209051L));
            Response<UnixTimestampDatetimeProperty> response = await client.UnixTimestampAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestamp_AllParameters()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1652209051,
            });
            Response response = client.UnixTimestamp(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestamp_AllParameters_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1652209051,
            });
            Response response = await client.UnixTimestampAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestamp_AllParameters_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampDatetimeProperty body = new UnixTimestampDatetimeProperty(DateTimeOffset.FromUnixTimeSeconds(1652209051L));
            Response<UnixTimestampDatetimeProperty> response = client.UnixTimestamp(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestamp_AllParameters_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampDatetimeProperty body = new UnixTimestampDatetimeProperty(DateTimeOffset.FromUnixTimeSeconds(1652209051L));
            Response<UnixTimestampDatetimeProperty> response = await client.UnixTimestampAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestampArray_ShortVersion()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
1652209051
            },
            });
            Response response = client.UnixTimestampArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestampArray_ShortVersion_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
1652209051
            },
            });
            Response response = await client.UnixTimestampArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestampArray_ShortVersion_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampArrayDatetimeProperty body = new UnixTimestampArrayDatetimeProperty(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });
            Response<UnixTimestampArrayDatetimeProperty> response = client.UnixTimestampArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestampArray_ShortVersion_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampArrayDatetimeProperty body = new UnixTimestampArrayDatetimeProperty(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });
            Response<UnixTimestampArrayDatetimeProperty> response = await client.UnixTimestampArrayAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestampArray_AllParameters()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
1652209051
            },
            });
            Response response = client.UnixTimestampArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestampArray_AllParameters_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
1652209051
            },
            });
            Response response = await client.UnixTimestampArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_UnixTimestampArray_AllParameters_Convenience()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampArrayDatetimeProperty body = new UnixTimestampArrayDatetimeProperty(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });
            Response<UnixTimestampArrayDatetimeProperty> response = client.UnixTimestampArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_UnixTimestampArray_AllParameters_Convenience_Async()
        {
            Property client = new DatetimeClient().GetPropertyClient();

            UnixTimestampArrayDatetimeProperty body = new UnixTimestampArrayDatetimeProperty(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });
            Response<UnixTimestampArrayDatetimeProperty> response = await client.UnixTimestampArrayAsync(body);
        }
    }
}
