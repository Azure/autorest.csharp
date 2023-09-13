// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Encode.Datetime.Samples
{
    internal class Samples_ResponseHeader
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Default();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Default();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.DefaultAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.DefaultAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Rfc3339();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc3339_AllParameters()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Rfc3339();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.Rfc3339Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc3339_AllParameters_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.Rfc3339Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Rfc7231();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rfc7231_AllParameters()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.Rfc7231();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.Rfc7231Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rfc7231_AllParameters_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.Rfc7231Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.UnixTimestamp();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimestamp_AllParameters()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = client.UnixTimestamp();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.UnixTimestampAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimestamp_AllParameters_Async()
        {
            var client = new DatetimeClient().GetResponseHeaderClient("1.0.0");

            Response response = await client.UnixTimestampAsync();
            Console.WriteLine(response.Status);
        }
    }
}
