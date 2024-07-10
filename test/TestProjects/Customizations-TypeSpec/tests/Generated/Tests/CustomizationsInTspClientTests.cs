// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using CustomizationsInTsp.Models;
using NUnit.Framework;

namespace CustomizationsInTsp.Tests
{
    public partial class CustomizationsInTspClientTests : CustomizationsInTspTestBase
    {
        public CustomizationsInTspClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_RoundTrip_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.RoundTripAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_RoundTrip_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RootModel input = new RootModel();
            Response<RootModel> response = await client.RoundTripAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_RoundTrip_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                propertyExtensibleEnum = "Monday",
                propertyModelToMakeInternal = new
                {
                    requiredInt = 1234,
                },
                propertyModelToRename = new
                {
                    requiredIntOnBase = 1234,
                    optionalInt = 1234,
                },
                propertyModelToChangeNamespace = new
                {
                    requiredInt = 1234,
                },
                propertyModelWithCustomizedProperties = new
                {
                    propertyToMakeInternal = 1234,
                    propertyToRename = 1234,
                    propertyToMakeFloat = 1234,
                    propertyToMakeInt = 123.45F,
                    propertyToMakeDuration = "<propertyToMakeDuration>",
                    propertyToMakeString = "PT1H23M45S",
                    propertyToMakeJsonElement = "<propertyToMakeJsonElement>",
                    propertyToField = "<propertyToField>",
                    badListName = new object[]
            {
"<badListName>"
            },
                    badDictionaryName = new
                    {
                        key = "<badDictionaryName>",
                    },
                    badListOfListName = new object[]
            {
new object[]
{
"<badListOfListName>"
}
            },
                    badListOfDictionaryName = new object[]
            {
new
{
key = "<badListOfDictionaryName>",
}
            },
                    vector = new object[]
            {
123.45F
            },
                    vectorOptional = new object[]
            {
123.45F
            },
                    vectorNullable = new object[]
            {
123.45F
            },
                    vectorOptionalNullable = new object[]
            {
123.45F
            },
                },
                propertyEnumToRename = "1",
                propertyEnumWithValueToRename = "1",
                propertyEnumToBeMadeExtensible = "1",
                propertyModelToAddAdditionalSerializableProperty = new
                {
                    requiredInt = 1234,
                    requiredIntOnBase = 1234,
                    optionalInt = 1234,
                },
                propertyToMoveToCustomization = "a",
                propertyModelStruct = new
                {
                    requiredInt = 1234,
                    optionalInt = 1234,
                    optionalString = "<optionalString>",
                },
            });
            Response response = await client.RoundTripAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_RoundTrip_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RootModel input = new RootModel
            {
                PropertyExtensibleEnum = ExtensibleEnumWithOperator.Monday,
                PropertyModelToRename = new RenamedModel(1234)
                {
                    OptionalInt = 1234,
                },
                PropertyModelToChangeNamespace = new ModelToChangeNamespace(1234),
                PropertyModelWithCustomizedProperties = new ModelWithCustomizedProperties(
                1234,
                1234,
                1234,
                (int)123.45F,
                XmlConvert.ToTimeSpan("<propertyToMakeDuration>"),
                "PT1H23M45S",
                default,
                "<propertyToField>",
                new string[] { "<badListName>" },
                new Dictionary<string, string>
                {
                    ["key"] = "<badDictionaryName>"
                },
                new IList<string>[]
            {
new string[]{"<badListOfListName>"}
            },
                new IDictionary<string, string>[]
            {
new Dictionary<string, string>
{
["key"] = "<badListOfDictionaryName>"
}
            },
                new float[] { 123.45F },
                new float[] { 123.45F })
                {
                    VectorOptional = new float[] { 123.45F },
                    VectorOptionalNullable = new float[] { 123.45F },
                },
                PropertyEnumToRename = RenamedEnum.One,
                PropertyEnumWithValueToRename = EnumWithValueToRename.One,
                PropertyEnumToBeMadeExtensible = EnumToBeMadeExtensible.ExOne,
                PropertyModelToAddAdditionalSerializableProperty = new ModelToAddAdditionalSerializableProperty(1234, 1234)
                {
                    OptionalInt = 1234,
                },
                PropertyToMoveToCustomization = NormalEnum.A,
                PropertyModelStruct = new ModelStruct(1234, 1234, "<optionalString>"),
            };
            Response<RootModel> response = await client.RoundTripAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Foo_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = await client.FooAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Foo_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234);
            Response<RenamedModel> response = await client.FooAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Foo_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = await client.FooAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Foo_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234)
            {
                OptionalInt = 1234,
            };
            Response<RenamedModel> response = await client.FooAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Bar_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = await client.BarAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Bar_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RenamedModel modelToRename = new RenamedModel(1234);
            Response<RenamedModel> response = await client.BarAsync(modelToRename);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Bar_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = await client.BarAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CustomizationsInTsp_Bar_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomizationsInTspClient client = CreateCustomizationsInTspClient(endpoint);

            RenamedModel modelToRename = new RenamedModel(1234)
            {
                OptionalInt = 1234,
            };
            Response<RenamedModel> response = await client.BarAsync(modelToRename);
        }
    }
}
