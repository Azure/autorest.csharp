// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Encode.Datetime.Samples
{
    public partial class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Default_ShortVersion()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Default_ShortVersion_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Default_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Default_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Rfc3339_ShortVersion()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Rfc3339_ShortVersion_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Rfc3339_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Rfc3339_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Rfc7231_ShortVersion()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Rfc7231_ShortVersion_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Rfc7231_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Rfc7231_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_UnixTimestamp_ShortVersion()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.UnixTimestamp(DateTimeOffset.FromUnixTimeSeconds(1652209051L));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_UnixTimestamp_ShortVersion_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.UnixTimestampAsync(DateTimeOffset.FromUnixTimeSeconds(1652209051L));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_UnixTimestamp_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.UnixTimestamp(DateTimeOffset.FromUnixTimeSeconds(1652209051L));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_UnixTimestamp_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.UnixTimestampAsync(DateTimeOffset.FromUnixTimeSeconds(1652209051L));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_UnixTimestampArray_ShortVersion()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.UnixTimestampArray(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_UnixTimestampArray_ShortVersion_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.UnixTimestampArrayAsync(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_UnixTimestampArray_AllParameters()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = client.UnixTimestampArray(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_UnixTimestampArray_AllParameters_Async()
        {
            Query client = new DatetimeClient().GetQueryClient();

            Response response = await client.UnixTimestampArrayAsync(new DateTimeOffset[] { DateTimeOffset.FromUnixTimeSeconds(1652209051L) });

            Console.WriteLine(response.Status);
        }
    }
}
