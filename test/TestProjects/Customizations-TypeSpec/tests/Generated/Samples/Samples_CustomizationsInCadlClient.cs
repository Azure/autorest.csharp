// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using CustomizationsInCadl.Models;
using NUnit.Framework;

namespace CustomizationsInCadl.Samples
{
    public class Samples_CustomizationsInCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip()
        {
            var client = new CustomizationsInCadlClient();

            var data = new { };

            Response response = client.RoundTrip(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTrip_AllParameters()
        {
            var client = new CustomizationsInCadlClient();

            var data = new
            {
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
                    propertyToMakeInt = 123.45f,
                    propertyToMakeDuration = "<propertyToMakeDuration>",
                    propertyToMakeString = "PT1H23M45S",
                    propertyToMakeJsonElement = "<propertyToMakeJsonElement>",
                    propertyToField = "<propertyToField>",
                    badListName = new[] {
            "<String>"
        },
                    badDictionaryName = new
                    {
                        key = "<String>",
                    },
                    badListOfListName = new[] {
            new[] {
                "<String>"
            }
        },
                    badListOfDictionaryName = new[] {
            new {
                key = "<String>",
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
            };

            Response response = client.RoundTrip(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
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
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badDictionaryName").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfListName")[0][0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfDictionaryName")[0].GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_Async()
        {
            var client = new CustomizationsInCadlClient();

            var data = new { };

            Response response = await client.RoundTripAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_AllParameters_Async()
        {
            var client = new CustomizationsInCadlClient();

            var data = new
            {
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
                    propertyToMakeInt = 123.45f,
                    propertyToMakeDuration = "<propertyToMakeDuration>",
                    propertyToMakeString = "PT1H23M45S",
                    propertyToMakeJsonElement = "<propertyToMakeJsonElement>",
                    propertyToField = "<propertyToField>",
                    badListName = new[] {
            "<String>"
        },
                    badDictionaryName = new
                    {
                        key = "<String>",
                    },
                    badListOfListName = new[] {
            new[] {
                "<String>"
            }
        },
                    badListOfDictionaryName = new[] {
            new {
                key = "<String>",
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
            };

            Response response = await client.RoundTripAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
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
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badDictionaryName").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfListName")[0][0].ToString());
            Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("badListOfDictionaryName")[0].GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
            Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
            Console.WriteLine(result.GetProperty("propertyModelToAddAdditionalSerializableProperty").GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTrip_Convenience_Async()
        {
            var client = new CustomizationsInCadlClient();

            var input = new RootModel()
            {
                PropertyModelToRename = new RenamedModel(1234)
                {
                    OptionalInt = 1234,
                },
                PropertyModelToChangeNamespace = new ModelToChangeNamespace(1234),
                PropertyModelWithCustomizedProperties = new ModelWithCustomizedProperties(1234, 1234, 3.14f, 1234, new TimeSpan(1, 2, 3), "<propertyToMakeString>", new JsonElement(), "<propertyToField>", new string[]
            {
        "<null>"
                }, new Dictionary<string, string>
                {
                    ["key"] = "<null>",
                }, new IList<string>[]
            {
        new string[]
{
            "<null>"
        }
                }, new IDictionary<string, string>[]
            {
        new Dictionary<string, string>
{
            ["key"] = "<null>",
        }
                }),
                PropertyEnumToRename = RenamedEnum.One,
                PropertyEnumWithValueToRename = EnumWithValueToRename.One,
                PropertyEnumToBeMadeExtensible = EnumToBeMadeExtensible.ExOne,
                PropertyModelToAddAdditionalSerializableProperty = new ModelToAddAdditionalSerializableProperty(1234)
                {
                    AdditionalSerializableProperty = 1234,
                    AdditionalNullableSerializableProperty = 1234,
                },
            };
            var result = await client.RoundTripAsync(input);
        }
    }
}
