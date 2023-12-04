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
using _Type.Model.Usage;
using _Type.Model.Usage.Models;

namespace _Type.Model.Usage.Tests
{
    public partial class UsageClientTests : _TypeModelUsageTestBase
    {
        public UsageClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Input_ShortVersion()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Input_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            InputRecord input = new InputRecord("<requiredProp>");
            Response response = await client.InputAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Input_AllParameters()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Input_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            InputRecord input = new InputRecord("<requiredProp>");
            Response response = await client.InputAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Output_ShortVersion()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            Response response = await client.OutputAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Output_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            Response<OutputRecord> response = await client.OutputAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Output_AllParameters()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            Response response = await client.OutputAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_Output_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            Response<OutputRecord> response = await client.OutputAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_InputAndOutput_ShortVersion()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAndOutputAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_InputAndOutput_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            InputOutputRecord body = new InputOutputRecord("<requiredProp>");
            Response<InputOutputRecord> response = await client.InputAndOutputAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_InputAndOutput_AllParameters()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAndOutputAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Usage_InputAndOutput_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UsageClient client = CreateUsageClient(endpoint);

            InputOutputRecord body = new InputOutputRecord("<requiredProp>");
            Response<InputOutputRecord> response = await client.InputAndOutputAsync(body);
        }
    }
}
