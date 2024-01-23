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
using dpg_initial_LowLevel;

namespace dpg_initial_LowLevel.Tests
{
    public partial class ParamsClientTests : dpg_initial_LowLevelTestBase
    {
        public ParamsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task HeadNoParams_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.HeadNoParamsAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task HeadNoParams_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.HeadNoParamsAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetRequired_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.GetRequiredAsync("<parameter>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetRequired_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.GetRequiredAsync("<parameter>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutRequiredOptional_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", null, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutRequiredOptional_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", "<optionalParam>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostParameters_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostParameters_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetOptional_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.GetOptionalAsync(null, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetOptional_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = CreateParamsClient(endpoint, credential);

            Response response = await client.GetOptionalAsync("<optionalParam>", null);
        }
    }
}