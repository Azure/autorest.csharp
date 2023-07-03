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
using Encode.Duration;
using NUnit.Framework;

namespace Encode.Duration.Samples
{
    internal class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Default(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Default(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.DefaultAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.DefaultAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Iso8601()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Iso8601(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Iso8601_AllParameters()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Iso8601(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Iso8601_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Iso8601Async(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Iso8601_AllParameters_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Iso8601Async(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32Seconds()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Int32Seconds(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32Seconds_AllParameters()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Int32Seconds(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32Seconds_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Int32SecondsAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32Seconds_AllParameters_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Int32SecondsAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSeconds()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.FloatSeconds(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatSeconds_AllParameters()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.FloatSeconds(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSeconds_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.FloatSecondsAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatSeconds_AllParameters_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.FloatSecondsAsync(new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32SecondsArray()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Int32SecondsArray(new TimeSpan[] { new TimeSpan(1, 2, 3) });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int32SecondsArray_AllParameters()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = client.Int32SecondsArray(new TimeSpan[] { new TimeSpan(1, 2, 3) });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32SecondsArray_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Int32SecondsArrayAsync(new TimeSpan[] { new TimeSpan(1, 2, 3) });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int32SecondsArray_AllParameters_Async()
        {
            Query client = new DurationClient().GetQueryClient("1.0.0");

            Response response = await client.Int32SecondsArrayAsync(new TimeSpan[] { new TimeSpan(1, 2, 3) });
            Console.WriteLine(response.Status);
        }
    }
}
