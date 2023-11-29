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
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public partial class Samples_Datetime
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_GetDatetime_ShortVersion()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetDatetime(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_GetDatetime_ShortVersion_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_GetDatetime_ShortVersion_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetDatetime();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_GetDatetime_ShortVersion_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetDatetimeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_GetDatetime_AllParameters()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetDatetime(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_GetDatetime_AllParameters_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_GetDatetime_AllParameters_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetDatetime();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_GetDatetime_AllParameters_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetDatetimeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_Put_ShortVersion()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_Put_ShortVersion_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_Put_ShortVersion_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_Put_ShortVersion_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_Put_AllParameters()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_Put_AllParameters_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Datetime_Put_AllParameters_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Datetime_Put_AllParameters_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = await client.PutAsync(body);
        }
    }
}
