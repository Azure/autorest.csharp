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
using CustomizationsInTsp;
using CustomizationsInTsp.Models;
using NUnit.Framework;

namespace CustomizationsInTsp.Samples
{
    public partial class Samples_CustomizationsInTspClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RequestContent content = RequestContent.Create(new object());
            Response response = client.RoundTrip(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_Async()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.RoundTripAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip_Convenience()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RootModel input = new RootModel();
            Response<RootModel> response = client.RoundTrip(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_Convenience_Async()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RootModel input = new RootModel();
            Response<RootModel> response = await client.RoundTripAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip_AllParameters()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RequestContent content = RequestContent.Create(new
            {
                propertyExtensibleEnum = "Monday",
                propertyModelToMakeInternal = new
                {
                    requiredInt = 1234,
                },
                propertyModelToRename = new
                {
                    requiredInt = 1234,
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
                },
                propertyEnumToRename = "1",
                propertyEnumWithValueToRename = "1",
                propertyEnumToBeMadeExtensible = "1",
                propertyModelToAddAdditionalSerializableProperty = new
                {
                    requiredInt = 1234,
                },
                propertyToMoveToCustomization = "a",
            });
            Response response = client.RoundTrip(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("propertyExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToChangeNamespace").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInternal").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeFloat").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeDuration").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeString").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeJsonElement").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToField").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListName")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badDictionaryName").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfListName")[0][0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfDictionaryName")[0].GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyToMoveToCustomization").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_AllParameters_Async()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RequestContent content = RequestContent.Create(new
            {
                propertyExtensibleEnum = "Monday",
                propertyModelToMakeInternal = new
                {
                    requiredInt = 1234,
                },
                propertyModelToRename = new
                {
                    requiredInt = 1234,
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
                },
                propertyEnumToRename = "1",
                propertyEnumWithValueToRename = "1",
                propertyEnumToBeMadeExtensible = "1",
                propertyModelToAddAdditionalSerializableProperty = new
                {
                    requiredInt = 1234,
                },
                propertyToMoveToCustomization = "a",
            });
            Response response = await client.RoundTripAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("propertyExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToChangeNamespace").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInternal").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeFloat").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeDuration").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeString").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeJsonElement").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToField").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListName")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badDictionaryName").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfListName")[0][0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfDictionaryName")[0].GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyToMoveToCustomization").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip_AllParameters_Convenience()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RootModel input = new RootModel
            {
                PropertyExtensibleEnum = ExtensibleEnumWithOperator.Monday,
                PropertyModelToRename = new RenamedModel(1234)
                {
                    OptionalInt = 1234,
                },
                PropertyModelToChangeNamespace = new ModelToChangeNamespace(1234),
                PropertyModelWithCustomizedProperties = new ModelWithCustomizedProperties(1234, 1234, 1234, (int)123.45F, XmlConvert.ToTimeSpan("<propertyToMakeDuration>"), "PT1H23M45S", default, "<propertyToField>", new string[] { "<badListName>" }, new Dictionary<string, string>
                {
                    ["key"] = "<badDictionaryName>"
                }, new IList<string>[]
            {
new string[]{"<badListOfListName>"}
            }, new IDictionary<string, string>[]
            {
new Dictionary<string, string>
{
["key"] = "<badListOfDictionaryName>"
}
            }),
                PropertyEnumToRename = RenamedEnum.One,
                PropertyEnumWithValueToRename = EnumWithValueToRename.One,
                PropertyEnumToBeMadeExtensible = EnumToBeMadeExtensible.ExOne,
                PropertyModelToAddAdditionalSerializableProperty = new ModelToAddAdditionalSerializableProperty(1234),
                PropertyToMoveToCustomization = NormalEnum.A,
            };
            Response<RootModel> response = client.RoundTrip(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_AllParameters_Convenience_Async()
        {
            CustomizationsInTspClient client = new CustomizationsInTspClient();

            RootModel input = new RootModel
            {
                PropertyExtensibleEnum = ExtensibleEnumWithOperator.Monday,
                PropertyModelToRename = new RenamedModel(1234)
                {
                    OptionalInt = 1234,
                },
                PropertyModelToChangeNamespace = new ModelToChangeNamespace(1234),
                PropertyModelWithCustomizedProperties = new ModelWithCustomizedProperties(1234, 1234, 1234, (int)123.45F, XmlConvert.ToTimeSpan("<propertyToMakeDuration>"), "PT1H23M45S", default, "<propertyToField>", new string[] { "<badListName>" }, new Dictionary<string, string>
                {
                    ["key"] = "<badDictionaryName>"
                }, new IList<string>[]
            {
new string[]{"<badListOfListName>"}
            }, new IDictionary<string, string>[]
            {
new Dictionary<string, string>
{
["key"] = "<badListOfDictionaryName>"
}
            }),
                PropertyEnumToRename = RenamedEnum.One,
                PropertyEnumWithValueToRename = EnumWithValueToRename.One,
                PropertyEnumToBeMadeExtensible = EnumToBeMadeExtensible.ExOne,
                PropertyModelToAddAdditionalSerializableProperty = new ModelToAddAdditionalSerializableProperty(1234),
                PropertyToMoveToCustomization = NormalEnum.A,
            };
            Response<RootModel> response = await client.RoundTripAsync(input);
        }
    }
}
