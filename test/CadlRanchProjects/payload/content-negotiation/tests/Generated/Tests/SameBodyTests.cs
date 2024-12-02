// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Payload.ContentNegotiation.Tests
{
    public partial class SameBodyTests : PayloadContentNegotiationTestBase
    {
        public SameBodyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsPng_ShortVersion()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response response = await client.GetAvatarAsPngAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsPng_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsPng_AllParameters()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response response = await client.GetAvatarAsPngAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsPng_AllParameters_Convenience()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response<BinaryData> response = await client.GetAvatarAsPngAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsJpeg_ShortVersion()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response response = await client.GetAvatarAsJpegAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsJpeg_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response<BinaryData> response = await client.GetAvatarAsJpegAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsJpeg_AllParameters()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response response = await client.GetAvatarAsJpegAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SameBody_GetAvatarAsJpeg_AllParameters_Convenience()
        {
            Uri endpoint = null;
            SameBody client = CreateContentNegotiationClient(endpoint).GetSameBodyClient();

            Response<BinaryData> response = await client.GetAvatarAsJpegAsync();
        }
    }
}
