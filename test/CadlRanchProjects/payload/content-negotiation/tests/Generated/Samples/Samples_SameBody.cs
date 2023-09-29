// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Payload.ContentNegotiation;

namespace Payload.ContentNegotiation.Samples
{
    public partial class Samples_SameBody
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_ShortVersion()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsPng(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_ShortVersion_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_ShortVersion_Convenience()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsPng();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_ShortVersion_Convenience_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_AllParameters()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsPng(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_AllParameters_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_AllParameters_Convenience()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsPng();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_AllParameters_Convenience_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJpeg_ShortVersion()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsJpeg(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJpeg_ShortVersion_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJpegAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJpeg_ShortVersion_Convenience()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsJpeg();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJpeg_ShortVersion_Convenience_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsJpegAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJpeg_AllParameters()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsJpeg(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJpeg_AllParameters_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJpegAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJpeg_AllParameters_Convenience()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsJpeg();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJpeg_AllParameters_Convenience_Async()
        {
            SameBody client = new ContentNegotiationClient().GetSameBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsJpegAsync();
        }
    }
}
