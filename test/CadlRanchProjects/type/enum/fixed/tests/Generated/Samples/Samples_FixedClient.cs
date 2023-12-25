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
using _Type._Enum.Fixed;
using _Type._Enum.Fixed.Models;

namespace _Type._Enum.Fixed.Samples
{
    public partial class Samples_FixedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_ShortVersion()
        {
            FixedClient client = new FixedClient();

            Response response = client.GetKnownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_ShortVersion_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.GetKnownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_ShortVersion_Convenience()
        {
            FixedClient client = new FixedClient();

            Response<DaysOfWeekEnum> response = client.GetKnownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_ShortVersion_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response<DaysOfWeekEnum> response = await client.GetKnownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_AllParameters()
        {
            FixedClient client = new FixedClient();

            Response response = client.GetKnownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_AllParameters_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.GetKnownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_AllParameters_Convenience()
        {
            FixedClient client = new FixedClient();

            Response<DaysOfWeekEnum> response = client.GetKnownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_AllParameters_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response<DaysOfWeekEnum> response = await client.GetKnownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_ShortVersion()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutKnownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_ShortVersion_Async()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutKnownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_ShortVersion_Convenience()
        {
            FixedClient client = new FixedClient();

            Response response = client.PutKnownValue(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_ShortVersion_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.PutKnownValueAsync(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_AllParameters()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutKnownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_AllParameters_Async()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutKnownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_AllParameters_Convenience()
        {
            FixedClient client = new FixedClient();

            Response response = client.PutKnownValue(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_AllParameters_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.PutKnownValueAsync(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_ShortVersion()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_ShortVersion_Async()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_ShortVersion_Convenience()
        {
            FixedClient client = new FixedClient();

            Response response = client.PutUnknownValue(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_ShortVersion_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.PutUnknownValueAsync(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_AllParameters()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_AllParameters_Async()
        {
            FixedClient client = new FixedClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_AllParameters_Convenience()
        {
            FixedClient client = new FixedClient();

            Response response = client.PutUnknownValue(DaysOfWeekEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_AllParameters_Convenience_Async()
        {
            FixedClient client = new FixedClient();

            Response response = await client.PutUnknownValueAsync(DaysOfWeekEnum.Monday);
        }
    }
}