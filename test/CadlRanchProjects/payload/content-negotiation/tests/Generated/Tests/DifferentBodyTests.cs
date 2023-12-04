// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Payload.ContentNegotiation;
using Payload.ContentNegotiation.Models;

namespace Payload.ContentNegotiation.Tests
{
    public partial class DifferentBodyTests : PayloadContentNegotiationTestBase
    {
        public DifferentBodyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsPng_ShortVersion()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsPng_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsPng_AllParameters()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsPngAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsPng_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsJson_ShortVersion()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJsonAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsJson_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = await client.GetAvatarAsJsonAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsJson_AllParameters()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response response = await client.GetAvatarAsJsonAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DifferentBody_GetAvatarAsJson_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DifferentBody client = CreateContentNegotiationClient(endpoint).GetDifferentBodyClient(apiVersion: "1.0.0");

            Response<PngImageAsJson> response = await client.GetAvatarAsJsonAsync();
        }
    }
}
