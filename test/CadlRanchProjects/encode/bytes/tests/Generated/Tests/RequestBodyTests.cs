// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Encode.Bytes;
using NUnit.Framework;

namespace Encode.Bytes.Tests
{
    public partial class RequestBodyTests : EncodeBytesTestBase
    {
        public RequestBodyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Default_ShortVersion()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.DefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Default_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Default_AllParameters()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.DefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Default_AllParameters_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_OctetStream_ShortVersion()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.OctetStreamAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_OctetStream_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.OctetStreamAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_OctetStream_AllParameters()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.OctetStreamAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_OctetStream_AllParameters_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.OctetStreamAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_CustomContentType_ShortVersion()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.CustomContentTypeAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_CustomContentType_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.CustomContentTypeAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_CustomContentType_AllParameters()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.CustomContentTypeAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_CustomContentType_AllParameters_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.CustomContentTypeAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64_ShortVersion()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.Base64Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.Base64Async(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64_AllParameters()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.Base64Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64_AllParameters_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.Base64Async(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64url_ShortVersion()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.Base64urlAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64url_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64url_AllParameters()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.Base64urlAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RequestBody_Base64url_AllParameters_Convenience()
        {
            Uri endpoint = null;
            RequestBody client = CreateBytesClient(endpoint).GetRequestBodyClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlAsync(BinaryData.FromObjectAsJson(new object()));
        }
    }
}
