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
using Versioning.Removed.BetaVersion.Models;

namespace Versioning.Removed.BetaVersion.Samples
{
    public partial class Samples_InterfaceV1
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InterfaceV1_V1InInterface_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V1InInterface(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InterfaceV1_V1InInterface_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1InInterfaceAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InterfaceV1_V1InInterface_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1InInterface(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InterfaceV1_V1InInterface_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1InInterfaceAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InterfaceV1_V1InInterface_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.V1InInterface(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InterfaceV1_V1InInterface_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1InInterfaceAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InterfaceV1_V1InInterface_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = client.V1InInterface(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InterfaceV1_V1InInterface_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            InterfaceV1 client = new RemovedClient(endpoint, default).GetInterfaceV1Client();

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1InInterfaceAsync(body);
        }
    }
}
