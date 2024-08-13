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
using Versioning.MadeOptional.Models;

namespace Versioning.MadeOptional.Samples
{
    public partial class Samples_MadeOptionalClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MadeOptional_Test_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
            });
            Response response = client.Test(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MadeOptional_Test_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
            });
            Response response = await client.TestAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MadeOptional_Test_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            TestModel body = new TestModel("<prop>");
            Response<TestModel> response = client.Test(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MadeOptional_Test_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            TestModel body = new TestModel("<prop>");
            Response<TestModel> response = await client.TestAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MadeOptional_Test_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = client.Test(content, param: "<param>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MadeOptional_Test_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = await client.TestAsync(content, param: "<param>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MadeOptional_Test_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            TestModel body = new TestModel("<prop>")
            {
                ChangedProp = "<changedProp>",
            };
            Response<TestModel> response = client.Test(body, param: "<param>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MadeOptional_Test_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MadeOptionalClient client = new MadeOptionalClient(endpoint, "<version>");

            TestModel body = new TestModel("<prop>")
            {
                ChangedProp = "<changedProp>",
            };
            Response<TestModel> response = await client.TestAsync(body, param: "<param>");
        }
    }
}
