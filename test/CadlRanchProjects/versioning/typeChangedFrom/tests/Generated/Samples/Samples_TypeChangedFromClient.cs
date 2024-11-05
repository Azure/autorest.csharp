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
using Versioning.TypeChangedFrom.Models;

namespace Versioning.TypeChangedFrom.Samples
{
    public partial class Samples_TypeChangedFromClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TypeChangedFrom_Test_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = client.Test("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TypeChangedFrom_Test_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = await client.TestAsync("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TypeChangedFrom_Test_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            TestModel body = new TestModel("<prop>", "<changedProp>");
            Response<TestModel> response = client.Test("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TypeChangedFrom_Test_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            TestModel body = new TestModel("<prop>", "<changedProp>");
            Response<TestModel> response = await client.TestAsync("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TypeChangedFrom_Test_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = client.Test("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TypeChangedFrom_Test_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                changedProp = "<changedProp>",
            });
            Response response = await client.TestAsync("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("changedProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TypeChangedFrom_Test_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            TestModel body = new TestModel("<prop>", "<changedProp>");
            Response<TestModel> response = client.Test("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TypeChangedFrom_Test_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TypeChangedFromClient client = new TypeChangedFromClient(endpoint, default);

            TestModel body = new TestModel("<prop>", "<changedProp>");
            Response<TestModel> response = await client.TestAsync("<param>", body);
        }
    }
}
