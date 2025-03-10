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

namespace CustomizationsInTsp.Samples
{
    public partial class Samples_CustomizationsInTspClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_RoundTrip_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.RoundTrip(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_RoundTrip_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.RoundTripAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_RoundTrip_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RootModel input = new RootModel();
            Response<RootModel> response = client.RoundTrip(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_RoundTrip_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RootModel input = new RootModel();
            Response<RootModel> response = await client.RoundTripAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_RoundTrip_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

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
            Response response = client.RoundTrip(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("propertyExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredIntOnBase").ToString());
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
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vector")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptional")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorNullable")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalNullable")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorNullableReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalNullableReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyToMoveToCustomization").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("optionalString").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_RoundTrip_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

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

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("propertyExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredIntOnBase").ToString());
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
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vector")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptional")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorNullable")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalNullable")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorNullableReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("vectorOptionalNullableReadOnly")[0].ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyToMoveToCustomization").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("propertyModelStruct").GetProperty("optionalString").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_RoundTrip_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

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
            Response<RootModel> response = client.RoundTrip(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_RoundTrip_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

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
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Foo_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = client.Foo(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Foo_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = await client.FooAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Foo_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234);
            Response<RenamedModel> response = client.Foo(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Foo_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234);
            Response<RenamedModel> response = await client.FooAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Foo_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = client.Foo(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Foo_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = await client.FooAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Foo_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234)
            {
                OptionalInt = 1234,
            };
            Response<RenamedModel> response = client.Foo(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Foo_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            RenamedModel input = new RenamedModel(1234)
            {
                OptionalInt = 1234,
            };
            Response<RenamedModel> response = await client.FooAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Bar_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = client.Bar(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Bar_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
            });
            Response response = await client.BarAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Bar_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            Response<RenamedModel> response = client.Bar(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Bar_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            Response<RenamedModel> response = await client.BarAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Bar_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = client.Bar(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Bar_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                requiredIntOnBase = 1234,
                optionalInt = 1234,
            });
            Response response = await client.BarAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredIntOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomizationsInTsp_Bar_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            Response<RenamedModel> response = client.Bar(1234, optionalInt: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomizationsInTsp_Bar_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            CustomizationsInTspClient client = new CustomizationsInTspClient(endpoint);

            Response<RenamedModel> response = await client.BarAsync(1234, optionalInt: 1234);
        }
    }
}
