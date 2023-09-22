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
using Payload.ContentNegotiation.Models;

namespace Payload.ContentNegotiation.Samples
{
    internal class Samples_DifferentBody
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsPng(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_Convenience()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsPng();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_Convenience_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_AllParameters()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsPng(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_AllParameters_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsPng_AllParameters_Convenience()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = client.GetAvatarAsPng();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsPng_AllParameters_Convenience_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJson()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsJson(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("content").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJson_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJsonAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("content").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJson_Convenience()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = client.GetAvatarAsJson();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJson_Convenience_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = await client.GetAvatarAsJsonAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJson_AllParameters()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = client.GetAvatarAsJson(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("content").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJson_AllParameters_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJsonAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("content").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAvatarAsJson_AllParameters_Convenience()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = client.GetAvatarAsJson();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAvatarAsJson_AllParameters_Convenience_Async()
        {
            DifferentBody client = new ContentNegotiationClient().GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = await client.GetAvatarAsJsonAsync();
        }
    }
}
