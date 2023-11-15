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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public partial class Samples_Datetime
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_ShortVersion()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_ShortVersion_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_ShortVersion_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_ShortVersion_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_ShortVersion()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_ShortVersion_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_ShortVersion_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_ShortVersion_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            Response<DatetimeProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_ShortVersion()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_ShortVersion_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_ShortVersion_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_ShortVersion_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty
            {
                Property = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty
            {
                Property = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_ShortVersion()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_ShortVersion_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_ShortVersion_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_ShortVersion_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters_Convenience()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty
            {
                Property = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Convenience_Async()
        {
            Datetime client = new OptionalClient().GetDatetimeClient();

            DatetimeProperty body = new DatetimeProperty
            {
                Property = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
