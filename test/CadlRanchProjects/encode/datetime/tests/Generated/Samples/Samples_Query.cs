// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Encode.Datetime;
using NUnit.Framework;

namespace Encode.Datetime.Samples
{
    public class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestamp(DateTimeOffset.FromUnixTimeSeconds(1652209051));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampAsync(DateTimeOffset.FromUnixTimeSeconds(1652209051));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestamp(DateTimeOffset.FromUnixTimeSeconds(1652209051));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampAsync(DateTimeOffset.FromUnixTimeSeconds(1652209051));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestampArray()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestampArray(new List<DateTimeOffset>()
{
DateTimeOffset.FromUnixTimeSeconds(1652209051)
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestampArray_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampArrayAsync(new List<DateTimeOffset>()
{
DateTimeOffset.FromUnixTimeSeconds(1652209051)
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestampArray_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestampArray(new List<DateTimeOffset>()
{
DateTimeOffset.FromUnixTimeSeconds(1652209051)
});
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestampArray_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampArrayAsync(new List<DateTimeOffset>()
{
DateTimeOffset.FromUnixTimeSeconds(1652209051)
});
            Console.WriteLine(response.Status);
        }
    }
}
