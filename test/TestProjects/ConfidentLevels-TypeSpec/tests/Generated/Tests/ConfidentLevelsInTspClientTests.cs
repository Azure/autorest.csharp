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
        public async Task ConfidentLevelsInTsp_UnionInRequestProperty_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UnionInRequestProperty_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithUnionProperty body = new ModelWithUnionProperty(BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UnionInRequestPropertyAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionInRequestProperty_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UnionInRequestProperty_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithUnionProperty body = new ModelWithUnionProperty(BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UnionInRequestPropertyAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionInResponseProperty_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UnionInResponseProperty_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            UsualModel body = new UsualModel("<name>", 1234);
            Response<AnotherModelWithUnionProperty> response = await client.UnionInResponsePropertyAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionInResponseProperty_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UnionInResponseProperty_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            UsualModel body = new UsualModel("<name>", 1234)
            {
                Size = 123.45,
            };
            Response<AnotherModelWithUnionProperty> response = await client.UnionInResponsePropertyAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionWithSelfReference_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UnionWithSelfReference_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            NonConfidentModelWithSelfReference input = new NonConfidentModelWithSelfReference("<name>", new NonConfidentModelWithSelfReference[]
            {
default
            }, BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UnionWithSelfReferenceAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionWithSelfReference_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UnionWithSelfReference_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            NonConfidentModelWithSelfReference input = new NonConfidentModelWithSelfReference("<name>", new NonConfidentModelWithSelfReference[]
            {
default
            }, BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UnionWithSelfReferenceAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionWithInderict_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UnionWithInderict_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            NonConfidentModelWithIndirectSelfReference input = new NonConfidentModelWithIndirectSelfReference("<name>");
            Response response = await client.UnionWithInderictAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnionWithInderict_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UnionWithInderict_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            NonConfidentModelWithIndirectSelfReference input = new NonConfidentModelWithIndirectSelfReference("<name>")
            {
                Reference = {new IndirectSelfReferenceModel("<something>", BinaryData.FromObjectAsJson("<unionProperty>"))
{
Reference = new NonConfidentModelWithSelfReference("<name>", new NonConfidentModelWithSelfReference[]
{
default
}, BinaryData.FromObjectAsJson("<unionProperty>")),
}},
            };
            Response response = await client.UnionWithInderictAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_LiteralOfInteger_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_LiteralOfInteger_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithIntegerLiteralTypeProperty input = new ModelWithIntegerLiteralTypeProperty("<name>");
            Response response = await client.LiteralOfIntegerAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_LiteralOfInteger_AllParameters()
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
        public async Task ConfidentLevelsInTsp_LiteralOfInteger_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithIntegerLiteralTypeProperty input = new ModelWithIntegerLiteralTypeProperty("<name>");
            Response response = await client.LiteralOfIntegerAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_LiteralOfFloat_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_LiteralOfFloat_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithFloatLiteralTypeProperty input = new ModelWithFloatLiteralTypeProperty("<name>");
            Response response = await client.LiteralOfFloatAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_LiteralOfFloat_AllParameters()
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
        public async Task ConfidentLevelsInTsp_LiteralOfFloat_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            ModelWithFloatLiteralTypeProperty input = new ModelWithFloatLiteralTypeProperty("<name>");
            Response response = await client.LiteralOfFloatAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_ConfidentOperationWithDiscriminator_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_ConfidentOperationWithDiscriminator_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            Pet input = new Cat("<name>", "<meow>");
            Response<Pet> response = await client.ConfidentOperationWithDiscriminatorAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_ConfidentOperationWithDiscriminator_AllParameters()
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
        public async Task ConfidentLevelsInTsp_ConfidentOperationWithDiscriminator_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            Pet input = new Cat("<name>", "<meow>");
            Response<Pet> response = await client.ConfidentOperationWithDiscriminatorAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_PollutedBaseMethod_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_PollutedBaseMethod_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            PollutedPet input = new PollutedDog("<name>", "<woof>", BinaryData.FromObjectAsJson("<color>"));
            Response<PollutedPet> response = await client.PollutedBaseMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_PollutedBaseMethod_AllParameters()
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
        public async Task ConfidentLevelsInTsp_PollutedBaseMethod_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            PollutedPet input = new PollutedDog("<name>", "<woof>", BinaryData.FromObjectAsJson("<color>"));
            Response<PollutedPet> response = await client.PollutedBaseMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_PollutedDerivedMethod_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_PollutedDerivedMethod_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            PollutedDog input = new PollutedDog("<name>", "<woof>", BinaryData.FromObjectAsJson("<color>"));
            Response<PollutedDog> response = await client.PollutedDerivedMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_PollutedDerivedMethod_AllParameters()
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
        public async Task ConfidentLevelsInTsp_PollutedDerivedMethod_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            PollutedDog input = new PollutedDog("<name>", "<woof>", BinaryData.FromObjectAsJson("<color>"));
            Response<PollutedDog> response = await client.PollutedDerivedMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnpollutedDerivedMethod_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UnpollutedDerivedMethod_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            UnpollutedCat input = new UnpollutedCat("<name>", "<meow>");
            Response<UnpollutedCat> response = await client.UnpollutedDerivedMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UnpollutedDerivedMethod_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UnpollutedDerivedMethod_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            UnpollutedCat input = new UnpollutedCat("<name>", "<meow>");
            Response<UnpollutedCat> response = await client.UnpollutedDerivedMethodAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UseDerivedModel_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UseDerivedModel_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            DerivedModel input = new DerivedModel("<name>");
            Response response = await client.UseDerivedModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UseDerivedModel_AllParameters()
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
        public async Task ConfidentLevelsInTsp_UseDerivedModel_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            DerivedModel input = new DerivedModel("<name>")
            {
                Age = 1234,
            };
            Response response = await client.UseDerivedModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UseDerivedModelWithUnion_ShortVersion()
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
        public async Task ConfidentLevelsInTsp_UseDerivedModelWithUnion_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            DerivedModelWithUnion input = new DerivedModelWithUnion("<name>", BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UseDerivedModelWithUnionAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UseDerivedModelWithUnion_AllParameters()
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

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConfidentLevelsInTsp_UseDerivedModelWithUnion_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ConfidentLevelsInTspClient client = CreateConfidentLevelsInTspClient(endpoint);

            DerivedModelWithUnion input = new DerivedModelWithUnion("<name>", BinaryData.FromObjectAsJson("<unionProperty>"));
            Response response = await client.UseDerivedModelWithUnionAsync(input);
        }
    }
}
