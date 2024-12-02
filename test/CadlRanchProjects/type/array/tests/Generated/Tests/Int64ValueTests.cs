// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace _Type._Array.Tests
{
    public partial class Int64ValueTests : _Type_ArrayTestBase
    {
        public Int64ValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_GetInt64Value_ShortVersion()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response response = await client.GetInt64ValueAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_GetInt64Value_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = await client.GetInt64ValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_GetInt64Value_AllParameters()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response response = await client.GetInt64ValueAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_GetInt64Value_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = await client.GetInt64ValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_Put_ShortVersion()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response response = await client.PutAsync(new long[] { 1234L });
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_Put_AllParameters()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Int64Value_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Int64Value client = CreateArrayClient(endpoint).GetInt64ValueClient();

            Response response = await client.PutAsync(new long[] { 1234L });
        }
    }
}
