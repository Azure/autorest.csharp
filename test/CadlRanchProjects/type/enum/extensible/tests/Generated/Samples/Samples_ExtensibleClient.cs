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
using _Type._Enum.Extensible;
using _Type._Enum.Extensible.Models;

namespace _Type._Enum.Extensible.Samples
{
    public partial class Samples_ExtensibleClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.GetKnownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.GetKnownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = client.GetKnownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = await client.GetKnownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_AllParameters()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.GetKnownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_AllParameters_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.GetKnownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue_AllParameters_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = client.GetKnownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetKnownValue_AllParameters_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = await client.GetKnownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.GetUnknownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.GetUnknownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = client.GetUnknownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = await client.GetUnknownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_AllParameters()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.GetUnknownValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_AllParameters_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.GetUnknownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_AllParameters_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = client.GetUnknownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_AllParameters_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response<DaysOfWeekExtensibleEnum> response = await client.GetUnknownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutKnownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutKnownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.PutKnownValue(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.PutKnownValueAsync(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_AllParameters()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutKnownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_AllParameters_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutKnownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue_AllParameters_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.PutKnownValue(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutKnownValue_AllParameters_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.PutKnownValueAsync(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.PutUnknownValue(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.PutUnknownValueAsync(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_AllParameters()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = client.PutUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_AllParameters_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            RequestContent content = RequestContent.Create("Monday");
            Response response = await client.PutUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue_AllParameters_Convenience()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = client.PutUnknownValue(DaysOfWeekExtensibleEnum.Monday);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUnknownValue_AllParameters_Convenience_Async()
        {
            ExtensibleClient client = new ExtensibleClient();

            Response response = await client.PutUnknownValueAsync(DaysOfWeekExtensibleEnum.Monday);
        }
    }
}
