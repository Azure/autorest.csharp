// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using ConfidentLevelsInTsp;
using ConfidentLevelsInTsp.Models;
using NUnit.Framework;

namespace ConfidentLevelsInTsp.Tests
{
    public partial class ConfidentLevelsInTspClientTests : ConfidentLevelsInTspTestBase
    {
        public ConfidentLevelsInTspClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionInRequestProperty_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                unionProperty = "<unionProperty>",
            });
            Response response = await client.UnionInRequestPropertyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionInRequestProperty_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                unionProperty = "<unionProperty>",
            });
            Response response = await client.UnionInRequestPropertyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionInResponseProperty_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.UnionInResponsePropertyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionInResponseProperty_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
                size = 123.45,
            });
            Response response = await client.UnionInResponsePropertyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionWithSelfReference_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                selfReference = new object[]
            {
null
            },
                unionProperty = "<unionProperty>",
            });
            Response response = await client.UnionWithSelfReferenceAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionWithSelfReference_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                selfReference = new object[]
            {
null
            },
                unionProperty = "<unionProperty>",
            });
            Response response = await client.UnionWithSelfReferenceAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionWithInderict_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.UnionWithInderictAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionWithInderict_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                reference = new object[]
            {
new
{
something = "<something>",
reference = new
{
name = "<name>",
selfReference = new object[]
{
null
},
unionProperty = "<unionProperty>",
},
unionProperty = "<unionProperty>",
}
            },
            });
            Response response = await client.UnionWithInderictAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task LiteralOfInteger_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                id = 1,
            });
            Response response = await client.LiteralOfIntegerAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task LiteralOfInteger_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                id = 1,
            });
            Response response = await client.LiteralOfIntegerAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task LiteralOfFloat_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                id = 3.141592F,
            });
            Response response = await client.LiteralOfFloatAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task LiteralOfFloat_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                id = 3.141592F,
            });
            Response response = await client.LiteralOfFloatAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentOperationWithDiscriminator_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                meow = "<meow>",
                kind = "cat",
                name = "<name>",
            });
            Response response = await client.ConfidentOperationWithDiscriminatorAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentOperationWithDiscriminator_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            Pet input = new Cat("<name>", "<meow>");
            Response<Pet> response = await client.ConfidentOperationWithDiscriminatorAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentOperationWithDiscriminator_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                meow = "<meow>",
                kind = "cat",
                name = "<name>",
            });
            Response response = await client.ConfidentOperationWithDiscriminatorAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentOperationWithDiscriminator_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            Pet input = new Cat("<name>", "<meow>");
            Response<Pet> response = await client.ConfidentOperationWithDiscriminatorAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PollutedBaseMethod_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                woof = "<woof>",
                color = "<color>",
                kind = "dog",
                name = "<name>",
            });
            Response response = await client.PollutedBaseMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PollutedBaseMethod_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                woof = "<woof>",
                color = "<color>",
                kind = "dog",
                name = "<name>",
            });
            Response response = await client.PollutedBaseMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PollutedDerivedMethod_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                woof = "<woof>",
                color = "<color>",
                kind = "dog",
                name = "<name>",
            });
            Response response = await client.PollutedDerivedMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PollutedDerivedMethod_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                woof = "<woof>",
                color = "<color>",
                kind = "dog",
                name = "<name>",
            });
            Response response = await client.PollutedDerivedMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnpollutedDerivedMethod_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                meow = "<meow>",
                kind = "cat",
                name = "<name>",
            });
            Response response = await client.UnpollutedDerivedMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnpollutedDerivedMethod_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                meow = "<meow>",
                kind = "cat",
                name = "<name>",
            });
            Response response = await client.UnpollutedDerivedMethodAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UseDerivedModel_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.UseDerivedModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UseDerivedModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                age = 1234,
                name = "<name>",
                size = 123.45,
            });
            Response response = await client.UseDerivedModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UseDerivedModelWithUnion_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                unionProperty = "<unionProperty>",
                name = "<name>",
            });
            Response response = await client.UseDerivedModelWithUnionAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UseDerivedModelWithUnion_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                unionProperty = "<unionProperty>",
                name = "<name>",
                size = 123.45,
            });
            Response response = await client.UseDerivedModelWithUnionAsync(content);
        }
    }
}
