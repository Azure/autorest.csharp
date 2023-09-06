// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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
    internal class Samples_Datetime
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetime()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetDatetime(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetime_AllParameters()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = client.GetDatetime(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetime_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetDatetime();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetime_AllParameters_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = client.GetDatetime();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetime_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetime_AllParameters_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetime_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetDatetimeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetime_AllParameters_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            Response<DatetimeProperty> response = await client.GetDatetimeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Datetime client = new ValueTypesClient().GetDatetimeClient(apiVersion: "1.0.0");

            DatetimeProperty body = new DatetimeProperty(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
