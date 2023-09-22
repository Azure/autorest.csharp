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
using FirstTestTypeSpec;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace FirstTestTypeSpec.Tests
{
    public class FirstTestTypeSpecClientTests : FirstTestTypeSpecTestBase
    {
        public FirstTestTypeSpecClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task TopAction_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.TopActionAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task TopAction_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.TopActionAsync(DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task TopAction2_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.TopAction2Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task TopAction2_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.TopAction2Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PatchAction_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.PatchActionAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PatchAction_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56F,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
                optionalNullableList = new List<object>()
{
1234
},
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.PatchActionAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task AnonymousBody_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.AnonymousBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task AnonymousBody_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56F,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
                optionalNullableList = new List<object>()
{
1234
},
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.AnonymousBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task FriendlyModel_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.FriendlyModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task FriendlyModel_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Friend notFriend = new Friend("<name>");
            Response<Friend> response = await client.FriendlyModelAsync(notFriend);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task FriendlyModel_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.FriendlyModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task FriendlyModel_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Friend notFriend = new Friend("<name>");
            Response<Friend> response = await client.FriendlyModelAsync(notFriend);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task AddTimeHeader_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.AddTimeHeaderAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task AddTimeHeader_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.AddTimeHeaderAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task StringFormat_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            });
            Response response = await client.StringFormatAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task StringFormat_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            ModelWithFormat body = new ModelWithFormat(new Uri("http://localhost:3000"), Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
            Response response = await client.StringFormatAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task StringFormat_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            });
            Response response = await client.StringFormatAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task StringFormat_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            ModelWithFormat body = new ModelWithFormat(new Uri("http://localhost:3000"), Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
            Response response = await client.StringFormatAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProjectedNameModel_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.ProjectedNameModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProjectedNameModel_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            ProjectedModel modelWithProjectedName = new ProjectedModel("<name>");
            Response<ProjectedModel> response = await client.ProjectedNameModelAsync(modelWithProjectedName);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProjectedNameModel_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.ProjectedNameModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProjectedNameModel_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            ProjectedModel modelWithProjectedName = new ProjectedModel("<name>");
            Response<ProjectedModel> response = await client.ProjectedNameModelAsync(modelWithProjectedName);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ReturnsAnonymousModel_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.ReturnsAnonymousModelAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ReturnsAnonymousModel_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.ReturnsAnonymousModelAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HeadAsBoolean_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response<bool> response = await client.HeadAsBooleanAsync("<id>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HeadAsBoolean_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response<bool> response = await client.HeadAsBooleanAsync("<id>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SayHi_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SayHi_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", "<optionalQuery>", null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloAgain_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new List<object>()
{
"1"
},
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = "<requiredUnion>",
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23F,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                    requiredNullableList = new List<object>()
{
1234
},
                },
                requiredUnknown = new object(),
                requiredRecordUnknown = new
                {
                    key = new object(),
                },
                modelWithRequiredNullable = new
                {
                    requiredNullablePrimitive = 1234,
                    requiredExtensibleEnum = "1",
                    requiredFixedEnum = "1",
                },
            });
            Response response = await client.HelloAgainAsync("<p2>", "<p1>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloAgain_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new List<object>()
{
"1"
},
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = "<requiredUnion>",
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23F,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56F,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                    optionalNullableList = new List<object>()
{
1234
},
                    requiredNullableList = new List<object>()
{
1234
},
                },
                intExtensibleEnum = 1,
                intExtensibleEnumCollection = new List<object>()
{
1
},
                floatExtensibleEnum = 1,
                floatExtensibleEnumCollection = new List<object>()
{
1
},
                floatFixedEnum = 1.1F,
                floatFixedEnumCollection = new List<object>()
{
1.1F
},
                intFixedEnum = 1,
                intFixedEnumCollection = new List<object>()
{
1
},
                stringFixedEnum = "1",
                requiredUnknown = new object(),
                optionalUnknown = new object(),
                requiredRecordUnknown = new
                {
                    key = new object(),
                },
                optionalRecordUnknown = new
                {
                    key = new object(),
                },
                modelWithRequiredNullable = new
                {
                    requiredNullablePrimitive = 1234,
                    requiredExtensibleEnum = "1",
                    requiredFixedEnum = "1",
                },
            });
            Response response = await client.HelloAgainAsync("<p2>", "<p1>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoContentType_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new List<object>()
{
"1"
},
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = "<requiredUnion>",
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23F,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                    requiredNullableList = new List<object>()
{
1234
},
                },
                requiredUnknown = new object(),
                requiredRecordUnknown = new
                {
                    key = new object(),
                },
                modelWithRequiredNullable = new
                {
                    requiredNullablePrimitive = 1234,
                    requiredExtensibleEnum = "1",
                    requiredFixedEnum = "1",
                },
            });
            Response response = await client.NoContentTypeAsync("<p2>", "<p1>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoContentType_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new List<object>()
{
"1"
},
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = "<requiredUnion>",
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23F,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56F,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                    optionalNullableList = new List<object>()
{
1234
},
                    requiredNullableList = new List<object>()
{
1234
},
                },
                intExtensibleEnum = 1,
                intExtensibleEnumCollection = new List<object>()
{
1
},
                floatExtensibleEnum = 1,
                floatExtensibleEnumCollection = new List<object>()
{
1
},
                floatFixedEnum = 1.1F,
                floatFixedEnumCollection = new List<object>()
{
1.1F
},
                intFixedEnum = 1,
                intFixedEnumCollection = new List<object>()
{
1
},
                stringFixedEnum = "1",
                requiredUnknown = new object(),
                optionalUnknown = new object(),
                requiredRecordUnknown = new
                {
                    key = new object(),
                },
                optionalRecordUnknown = new
                {
                    key = new object(),
                },
                modelWithRequiredNullable = new
                {
                    requiredNullablePrimitive = 1234,
                    requiredExtensibleEnum = "1",
                    requiredFixedEnum = "1",
                },
            });
            Response response = await client.NoContentTypeAsync("<p2>", "<p1>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloDemo2_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.HelloDemo2Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloDemo2_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.HelloDemo2Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task CreateLiteral_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.CreateLiteralAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task CreateLiteral_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                requiredUnion = "<requiredUnion>",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23F,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56F,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
                optionalNullableList = new List<object>()
{
1234
},
                requiredNullableList = new List<object>()
{
1234
},
            });
            Response response = await client.CreateLiteralAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloLiteral_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.HelloLiteralAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HelloLiteral_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.HelloLiteralAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownValue_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.GetUnknownValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.GetUnknownValueAsync(null);
        }
    }
}
