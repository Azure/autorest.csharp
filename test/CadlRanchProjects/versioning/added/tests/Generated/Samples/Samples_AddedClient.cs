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
using Versioning.Added.Models;

namespace Versioning.Added.Samples
{
    public partial class Samples_AddedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V1_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = client.V1("<headerV2>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V1_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async("<headerV2>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V1_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1("<headerV2>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V1_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async("<headerV2>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V1_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = client.V1("<headerV2>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V1_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async("<headerV2>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V1_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1("<headerV2>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V1_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async("<headerV2>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V2_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V2(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V2_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V2_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = client.V2(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V2_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V2_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V2(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V2_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Added_V2_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = client.V2(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Added_V2_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AddedClient client = new AddedClient(endpoint, Versions.V1);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async(body);
        }
    }
}
