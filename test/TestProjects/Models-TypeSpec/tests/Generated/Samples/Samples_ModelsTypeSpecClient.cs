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
using ModelsTypeSpec.Models;
using NUnit.Framework;

namespace ModelsTypeSpec.Samples
{
    public class Samples_ModelsTypeSpecClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOutputDiscriminatorModel()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = client.GetOutputDiscriminatorModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOutputDiscriminatorModel_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = client.GetOutputDiscriminatorModel(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOutputDiscriminatorModel_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = await client.GetOutputDiscriminatorModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOutputDiscriminatorModel_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = await client.GetOutputDiscriminatorModelAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOutputDiscriminatorModel_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var result = await client.GetOutputDiscriminatorModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTrip()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = client.InputToRoundTrip(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("discriminatorProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedIntEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredBytes").ToString());
            Console.WriteLine(result.GetProperty("requiredUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredInt8Array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTrip_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = client.InputToRoundTrip(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("discriminatorProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedIntEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredBytes").ToString());
            Console.WriteLine(result.GetProperty("optionalBytes").ToString());
            Console.WriteLine(result.GetProperty("requiredUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredInt8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalInt8Array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTrip_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = await client.InputToRoundTripAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("discriminatorProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedIntEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredBytes").ToString());
            Console.WriteLine(result.GetProperty("requiredUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredInt8Array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTrip_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = await client.InputToRoundTripAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("discriminatorProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredFixedIntEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredBytes").ToString());
            Console.WriteLine(result.GetProperty("optionalBytes").ToString());
            Console.WriteLine(result.GetProperty("requiredUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalUint8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredInt8Array")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalInt8Array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTrip_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var input = new InputModel("<requiredString>", 1234, new BaseModel(), new int[]
            {
    1234
            }, new string[]
            {
    "<null>"
            }, new CollectionItem[]
            {
    new CollectionItem(new Dictionary<string, RecordItem>
{
        ["key"] = new RecordItem(Array.Empty<CollectionItem>()),
    })
            }, new Dictionary<string, RecordItem>(), new float?[]
            {
    3.14f
            }, new bool?[]
            {
    true
            });
            var result = await client.InputToRoundTripAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTripPrimitive()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = client.InputToRoundTripPrimitive(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredInt64").ToString());
            Console.WriteLine(result.GetProperty("requiredSafeInt").ToString());
            Console.WriteLine(result.GetProperty("requiredFloat").ToString());
            Console.WriteLine(result.GetProperty("required_Double").ToString());
            Console.WriteLine(result.GetProperty("requiredBoolean").ToString());
            Console.WriteLine(result.GetProperty("requiredDateTimeOffset").ToString());
            Console.WriteLine(result.GetProperty("requiredTimeSpan").ToString());
            Console.WriteLine(result.GetProperty("requiredCollectionWithNullableFloatElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTripPrimitive_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = client.InputToRoundTripPrimitive(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredInt64").ToString());
            Console.WriteLine(result.GetProperty("requiredSafeInt").ToString());
            Console.WriteLine(result.GetProperty("requiredFloat").ToString());
            Console.WriteLine(result.GetProperty("required_Double").ToString());
            Console.WriteLine(result.GetProperty("requiredBoolean").ToString());
            Console.WriteLine(result.GetProperty("requiredDateTimeOffset").ToString());
            Console.WriteLine(result.GetProperty("requiredTimeSpan").ToString());
            Console.WriteLine(result.GetProperty("requiredCollectionWithNullableFloatElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTripPrimitive_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = await client.InputToRoundTripPrimitiveAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredInt64").ToString());
            Console.WriteLine(result.GetProperty("requiredSafeInt").ToString());
            Console.WriteLine(result.GetProperty("requiredFloat").ToString());
            Console.WriteLine(result.GetProperty("required_Double").ToString());
            Console.WriteLine(result.GetProperty("requiredBoolean").ToString());
            Console.WriteLine(result.GetProperty("requiredDateTimeOffset").ToString());
            Console.WriteLine(result.GetProperty("requiredTimeSpan").ToString());
            Console.WriteLine(result.GetProperty("requiredCollectionWithNullableFloatElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTripPrimitive_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new { },
                requiredIntCollection = new[] {
        1234
    },
                requiredStringCollection = new[] {
        "<String>"
    },
                requiredModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredCollectionWithNullableFloatElement = new[] {
        123.45f
    },
                requiredCollectionWithNullableBooleanElement = new[] {
        true
    },
            };

            Response response = await client.InputToRoundTripPrimitiveAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredInt64").ToString());
            Console.WriteLine(result.GetProperty("requiredSafeInt").ToString());
            Console.WriteLine(result.GetProperty("requiredFloat").ToString());
            Console.WriteLine(result.GetProperty("required_Double").ToString());
            Console.WriteLine(result.GetProperty("requiredBoolean").ToString());
            Console.WriteLine(result.GetProperty("requiredDateTimeOffset").ToString());
            Console.WriteLine(result.GetProperty("requiredTimeSpan").ToString());
            Console.WriteLine(result.GetProperty("requiredCollectionWithNullableFloatElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTripPrimitive_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var input = new InputModel("<requiredString>", 1234, new BaseModel(), new int[]
            {
    1234
            }, new string[]
            {
    "<null>"
            }, new CollectionItem[]
            {
    new CollectionItem(new Dictionary<string, RecordItem>
{
        ["key"] = new RecordItem(Array.Empty<CollectionItem>()),
    })
            }, new Dictionary<string, RecordItem>(), new float?[]
            {
    3.14f
            }, new bool?[]
            {
    true
            });
            var result = await client.InputToRoundTripPrimitiveAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTripOptional()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new { };

            Response response = client.InputToRoundTripOptional(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToRoundTripOptional_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                optionalString = "<optionalString>",
                optionalInt = 1234,
                optionalStringList = new[] {
        "<String>"
    },
                optionalIntList = new[] {
        1234
    },
                optionalModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                optionalModel = new { },
                optionalModelWithPropertiesOnBase = new
                {
                    optionalPropertyOnBase = "<optionalPropertyOnBase>",
                },
                optionalFixedStringEnum = "1",
                optionalExtensibleEnum = "1",
                optionalIntRecord = new
                {
                    key = 1234,
                },
                optionalStringRecord = new
                {
                    key = "<String>",
                },
                optionalModelRecord = new
                {
                    key = new { },
                },
                optionalPlainDate = "2022-05-10",
                optionalPlainTime = "01:23:45",
                optionalCollectionWithNullableIntElement = new[] {
        1234
    },
            };

            Response response = client.InputToRoundTripOptional(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalString").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("optionalStringList")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalIntList")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalModelWithPropertiesOnBase").GetProperty("optionalPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("optionalExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("optionalIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalPlainDate").ToString());
            Console.WriteLine(result.GetProperty("optionalPlainTime").ToString());
            Console.WriteLine(result.GetProperty("optionalCollectionWithNullableIntElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTripOptional_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new { };

            Response response = await client.InputToRoundTripOptionalAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToRoundTripOptional_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                optionalString = "<optionalString>",
                optionalInt = 1234,
                optionalStringList = new[] {
        "<String>"
    },
                optionalIntList = new[] {
        1234
    },
                optionalModelCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                optionalModel = new { },
                optionalModelWithPropertiesOnBase = new
                {
                    optionalPropertyOnBase = "<optionalPropertyOnBase>",
                },
                optionalFixedStringEnum = "1",
                optionalExtensibleEnum = "1",
                optionalIntRecord = new
                {
                    key = 1234,
                },
                optionalStringRecord = new
                {
                    key = "<String>",
                },
                optionalModelRecord = new
                {
                    key = new { },
                },
                optionalPlainDate = "2022-05-10",
                optionalPlainTime = "01:23:45",
                optionalCollectionWithNullableIntElement = new[] {
        1234
    },
            };

            Response response = await client.InputToRoundTripOptionalAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalString").ToString());
            Console.WriteLine(result.GetProperty("optionalInt").ToString());
            Console.WriteLine(result.GetProperty("optionalStringList")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalIntList")[0].ToString());
            Console.WriteLine(result.GetProperty("optionalModelWithPropertiesOnBase").GetProperty("optionalPropertyOnBase").ToString());
            Console.WriteLine(result.GetProperty("optionalFixedStringEnum").ToString());
            Console.WriteLine(result.GetProperty("optionalExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("optionalIntRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalStringRecord").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalPlainDate").ToString());
            Console.WriteLine(result.GetProperty("optionalPlainTime").ToString());
            Console.WriteLine(result.GetProperty("optionalCollectionWithNullableIntElement")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripToOutput()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new
                {
                    discriminatorProperty = "",
                    requiredPropertyOnBase = 1234,
                },
                requiredFixedStringEnum = "1",
                requiredFixedIntEnum = "1",
                requiredExtensibleEnum = "1",
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredIntRecord = new
                {
                    key = 1234,
                },
                requiredStringRecord = new
                {
                    key = "<String>",
                },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredBytes = new { },
                requiredUint8Array = new[] {
        1234
    },
                requiredUnknown = new { },
                requiredInt8Array = new[] {
        1234
    },
            };

            Response response = client.RoundTripToOutput(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripToOutput_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new
                {
                    discriminatorProperty = "",
                    optionalPropertyOnBase = "<optionalPropertyOnBase>",
                    requiredPropertyOnBase = 1234,
                },
                requiredFixedStringEnum = "1",
                requiredFixedIntEnum = "1",
                requiredExtensibleEnum = "1",
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredIntRecord = new
                {
                    key = 1234,
                },
                requiredStringRecord = new
                {
                    key = "<String>",
                },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredBytes = new { },
                optionalBytes = new { },
                requiredUint8Array = new[] {
        1234
    },
                optionalUint8Array = new[] {
        1234
    },
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredInt8Array = new[] {
        1234
    },
                optionalInt8Array = new[] {
        1234
    },
            };

            Response response = client.RoundTripToOutput(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripToOutput_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new
                {
                    discriminatorProperty = "",
                    requiredPropertyOnBase = 1234,
                },
                requiredFixedStringEnum = "1",
                requiredFixedIntEnum = "1",
                requiredExtensibleEnum = "1",
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredIntRecord = new
                {
                    key = 1234,
                },
                requiredStringRecord = new
                {
                    key = "<String>",
                },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredBytes = new { },
                requiredUint8Array = new[] {
        1234
    },
                requiredUnknown = new { },
                requiredInt8Array = new[] {
        1234
    },
            };

            Response response = await client.RoundTripToOutputAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripToOutput_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredModel = new
                {
                    discriminatorProperty = "",
                    optionalPropertyOnBase = "<optionalPropertyOnBase>",
                    requiredPropertyOnBase = 1234,
                },
                requiredFixedStringEnum = "1",
                requiredFixedIntEnum = "1",
                requiredExtensibleEnum = "1",
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                requiredIntRecord = new
                {
                    key = 1234,
                },
                requiredStringRecord = new
                {
                    key = "<String>",
                },
                requiredModelRecord = new
                {
                    key = new { },
                },
                requiredBytes = new { },
                optionalBytes = new { },
                requiredUint8Array = new[] {
        1234
    },
                optionalUint8Array = new[] {
        1234
    },
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredInt8Array = new[] {
        1234
    },
                optionalInt8Array = new[] {
        1234
    },
            };

            Response response = await client.RoundTripToOutputAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputRecursive()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = client.InputRecursive(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputRecursive_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = client.InputRecursive(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputRecursive_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = await client.InputRecursiveAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputRecursive_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = await client.InputRecursiveAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputRecursive_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var input = new InputRecursiveModel("<message>");
            var result = await client.InputRecursiveAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripRecursive()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = client.RoundTripRecursive(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripRecursive_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = client.RoundTripRecursive(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("inner").GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripRecursive_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = await client.RoundTripRecursiveAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripRecursive_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                message = "<message>",
            };

            Response response = await client.RoundTripRecursiveAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("inner").GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripRecursive_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var input = new RoundTripRecursiveModel("<message>");
            var result = await client.RoundTripRecursiveAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SelfReference()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = client.SelfReference(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SelfReference_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = client.SelfReference(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("innerError").GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SelfReference_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = await client.SelfReferenceAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SelfReference_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            Response response = await client.SelfReferenceAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("innerError").GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SelfReference_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var result = await client.SelfReferenceAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripToOutputWithNoUseBase()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                baseModelProp = "<baseModelProp>",
            };

            Response response = client.RoundTripToOutputWithNoUseBase(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("baseModelProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RoundTripToOutputWithNoUseBase_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                baseModelProp = "<baseModelProp>",
            };

            Response response = client.RoundTripToOutputWithNoUseBase(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("baseModelProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripToOutputWithNoUseBase_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                baseModelProp = "<baseModelProp>",
            };

            Response response = await client.RoundTripToOutputWithNoUseBaseAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("baseModelProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripToOutputWithNoUseBase_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var data = new
            {
                requiredCollection = new[] {
        new {
            requiredModelRecord = new {
                key = new {},
            },
        }
    },
                baseModelProp = "<baseModelProp>",
            };

            Response response = await client.RoundTripToOutputWithNoUseBaseAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("baseModelProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RoundTripToOutputWithNoUseBase_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ModelsTypeSpecClient(endpoint);

            var input = new RoundTripOnNoUse("<baseModelProp>", new CollectionItem[]
            {
    new CollectionItem(new Dictionary<string, RecordItem>
{
        ["key"] = new RecordItem(Array.Empty<CollectionItem>()),
    })
            });
            var result = await client.RoundTripToOutputWithNoUseBaseAsync(input);
        }
    }
}
