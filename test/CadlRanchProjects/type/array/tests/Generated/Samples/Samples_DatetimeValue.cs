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
using _Type._Array;

namespace _Type._Array.Samples
{
    internal class Samples_DatetimeValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = client.GetDatetimeValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue_Convenience()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<DateTimeOffset>> response = client.GetDatetimeValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_Convenience_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<DateTimeOffset>> response = await client.GetDatetimeValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue_AllParameters()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = client.GetDatetimeValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_AllParameters_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = await client.GetDatetimeValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue_AllParameters_Convenience()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<DateTimeOffset>> response = client.GetDatetimeValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_AllParameters_Convenience_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<DateTimeOffset>> response = await client.GetDatetimeValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"2022-05-10T14:57:31.2311892-04:00"
});
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"2022-05-10T14:57:31.2311892-04:00"
});
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new List<DateTimeOffset>()
{
DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00")
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<DateTimeOffset>()
{
DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00")
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"2022-05-10T14:57:31.2311892-04:00"
});
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"2022-05-10T14:57:31.2311892-04:00"
});
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new List<DateTimeOffset>()
{
DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00")
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            DatetimeValue client = new ArrayClient().GetDatetimeValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<DateTimeOffset>()
{
DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00")
});
            Console.WriteLine(response.Status);
        }
    }
}
