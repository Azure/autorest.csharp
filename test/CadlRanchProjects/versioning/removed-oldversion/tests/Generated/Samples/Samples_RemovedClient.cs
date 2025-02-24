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
using Versioning.Removed.OldVersion.Models;

namespace Versioning.Removed.OldVersion.Samples
{
    public partial class Samples_RemovedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V1_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V1(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V1_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V1_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V1_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V1_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V1(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V1_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V1_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V1_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V2_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = client.V2("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("removedProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V2_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("removedProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V2_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = client.V2("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V2_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V2_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = client.V2("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("removedProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V2_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async("<param>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("removedProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_V2_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = client.V2("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_V2_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async("<param>", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_ModelV3_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = client.ModelV3(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_ModelV3_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = await client.ModelV3Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_ModelV3_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = client.ModelV3(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_ModelV3_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = await client.ModelV3Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_ModelV3_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = client.ModelV3(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_ModelV3_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = await client.ModelV3Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Removed_ModelV3_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = client.ModelV3(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Removed_ModelV3_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = new RemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = await client.ModelV3Async(body);
        }
    }
}
