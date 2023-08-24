// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Encode.Datetime;
using NUnit.Framework;

namespace Encode.Datetime.Samples
{
    internal class Samples_Header
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Default(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339_AllParameters()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Rfc3339(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_AllParameters_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.Rfc3339Async(DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231_AllParameters()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.Rfc7231(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_AllParameters_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.Rfc7231Async(DateTimeOffset.Parse("Tue, 10 May 2022 18:57:31 GMT"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestamp(DateTimeOffset.Parse("1652209051"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp_AllParameters()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestamp(DateTimeOffset.Parse("1652209051"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampAsync(DateTimeOffset.Parse("1652209051"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_AllParameters_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampAsync(DateTimeOffset.Parse("1652209051"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestampArray()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestampArray(new DateTimeOffset[]
            {
DateTimeOffset.Parse("1652209051")
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestampArray_AllParameters()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = client.UnixTimestampArray(new DateTimeOffset[]
            {
DateTimeOffset.Parse("1652209051")
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestampArray_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampArrayAsync(new DateTimeOffset[]
            {
DateTimeOffset.Parse("1652209051")
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestampArray_AllParameters_Async()
        {
            Header client = new DatetimeClient().GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.UnixTimestampArrayAsync(new DateTimeOffset[]
            {
DateTimeOffset.Parse("1652209051")
            });
            Console.WriteLine(response.Status);
        }
    }
}
