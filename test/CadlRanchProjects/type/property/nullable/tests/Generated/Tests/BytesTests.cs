// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable.Tests
{
    public partial class BytesTests : _TypePropertyNullableTestBase
    {
        public BytesTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNonNull_ShortVersion()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response response = await client.GetNonNullAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNonNull_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response<BytesProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNonNull_AllParameters()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response response = await client.GetNonNullAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNonNull_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response<BytesProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNull_ShortVersion()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response response = await client.GetNullAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNull_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response<BytesProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNull_AllParameters()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response response = await client.GetNullAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_GetNull_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            Response<BytesProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_PatchNonNull_ShortVersion()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNonNullAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_PatchNonNull_AllParameters()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNonNullAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_PatchNull_ShortVersion()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNullAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Bytes_PatchNull_AllParameters()
        {
            Uri endpoint = null;
            Bytes client = CreateNullableClient(endpoint).GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object(),
            });
            Response response = await client.PatchNullAsync(content);
        }
    }
}
