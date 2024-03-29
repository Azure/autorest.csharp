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
using body_complex_LowLevel;

namespace body_complex_LowLevel.Tests
{
    public partial class PrimitiveClientTests : body_complex_LowLevelTestBase
    {
        public PrimitiveClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetInt_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetIntAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetInt_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetIntAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutInt_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutIntAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutInt_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field1 = 1234,
                field2 = 1234,
            });
            Response response = await client.PutIntAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetLong_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetLongAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetLong_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetLongAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutLong_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutLongAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutLong_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field1 = 1234L,
                field2 = 1234L,
            });
            Response response = await client.PutLongAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetFloat_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetFloatAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetFloat_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetFloatAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutFloat_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutFloatAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutFloat_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field1 = 123.45F,
                field2 = 123.45F,
            });
            Response response = await client.PutFloatAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDouble_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDoubleAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDouble_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDoubleAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDouble_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDoubleAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDouble_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field1 = 123.45,
                field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose = 123.45,
            });
            Response response = await client.PutDoubleAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetBool_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetBoolAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetBool_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetBoolAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutBool_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutBoolAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutBool_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field_true = true,
                field_false = true,
            });
            Response response = await client.PutBoolAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetString_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetString_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutString_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutStringAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutString_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["field"] = "<field>",
                ["empty"] = "<empty>",
                ["null"] = "<null>"
            });
            Response response = await client.PutStringAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDate_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDate_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDate_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDateAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDate_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field = "2022-05-10",
                leap = "2022-05-10",
            });
            Response response = await client.PutDateAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDateTime_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateTimeAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDateTime_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateTimeAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDateTime_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDateTimeAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDateTime_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field = "2022-05-10T18:57:31.2311892Z",
                now = "2022-05-10T18:57:31.2311892Z",
            });
            Response response = await client.PutDateTimeAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDateTimeRfc1123_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateTimeRfc1123Async(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDateTimeRfc1123_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDateTimeRfc1123Async(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDateTimeRfc1123_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDateTimeRfc1123Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDateTimeRfc1123_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field = "Tue, 10 May 2022 18:57:31 GMT",
                now = "Tue, 10 May 2022 18:57:31 GMT",
            });
            Response response = await client.PutDateTimeRfc1123Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDuration_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDurationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetDuration_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetDurationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDuration_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDurationAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutDuration_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field = "PT1H23M45S",
            });
            Response response = await client.PutDurationAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetByte_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetByteAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetByte_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            Response response = await client.GetByteAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutByte_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutByteAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutByte_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PrimitiveClient client = CreatePrimitiveClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                field = new object(),
            });
            Response response = await client.PutByteAsync(content);
        }
    }
}
