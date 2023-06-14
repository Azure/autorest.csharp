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
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace FirstTestTypeSpec.Samples
{
    public class Samples_FirstTestTypeSpecClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TopAction()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.TopAction(DateTimeOffset.UtcNow, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TopAction_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.TopAction(DateTimeOffset.UtcNow, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TopAction_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.TopActionAsync(DateTimeOffset.UtcNow, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TopAction_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.TopActionAsync(DateTimeOffset.UtcNow, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TopAction_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var result = await client.TopActionAsync(DateTimeOffset.UtcNow);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TopAction2()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.TopAction2();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TopAction2_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.TopAction2();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TopAction2_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.TopAction2Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TopAction2_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.TopAction2Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchAction()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.PatchAction(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchAction_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.PatchAction(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchAction_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.PatchActionAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchAction_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.PatchActionAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnonymousBody()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.AnonymousBody(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnonymousBody_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.AnonymousBody(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnonymousBody_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.AnonymousBodyAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnonymousBody_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.AnonymousBodyAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnonymousBody_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var thing = new Thing("<name>", "<requiredUnion>", "<requiredBadDescription>")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
                OptionalLiteralBool = true,
            };
            var result = await client.AnonymousBodyAsync(thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FriendlyModel()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            Response response = client.FriendlyModel(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FriendlyModel_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            Response response = client.FriendlyModel(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FriendlyModel_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.FriendlyModelAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FriendlyModel_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.FriendlyModelAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FriendlyModel_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var notFriend = new Friend("<name>");
            var result = await client.FriendlyModelAsync(notFriend);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AddTimeHeader()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.AddTimeHeader();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AddTimeHeader_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.AddTimeHeader(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AddTimeHeader_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.AddTimeHeaderAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AddTimeHeader_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.AddTimeHeaderAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringFormat()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            };

            Response response = client.StringFormat(Guid.NewGuid(), RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringFormat_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            };

            Response response = client.StringFormat(Guid.NewGuid(), RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringFormat_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            };

            Response response = await client.StringFormatAsync(Guid.NewGuid(), RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringFormat_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                sourceUrl = "http://localhost:3000",
                guid = "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a",
            };

            Response response = await client.StringFormatAsync(Guid.NewGuid(), RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringFormat_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var body = new ModelWithFormat(new Uri("http://localhost:3000"), Guid.NewGuid());
            var result = await client.StringFormatAsync(Guid.NewGuid(), body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SayHi()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.SayHi("<headParameter>", "<queryParameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SayHi_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.SayHi("<headParameter>", "<queryParameter>", "<optionalQuery>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SayHi_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SayHi_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", "<optionalQuery>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloAgain()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                requiredUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = client.HelloAgain("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloAgain_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                intExtensibleEnum = "1",
                intExtensibleEnumCollection = new[] {
        "1"
    },
                floatExtensibleEnum = "1",
                floatExtensibleEnumCollection = new[] {
        "1"
    },
                floatFixedEnum = "1.1",
                floatFixedEnumCollection = new[] {
        "1.1"
    },
                intFixedEnum = "1",
                intFixedEnumCollection = new[] {
        "1"
    },
                stringFixedEnum = "1",
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
                optionalRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = client.HelloAgain("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("intFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("intFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("stringFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyOptionalRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloAgain_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                requiredUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = await client.HelloAgainAsync("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloAgain_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                intExtensibleEnum = "1",
                intExtensibleEnumCollection = new[] {
        "1"
    },
                floatExtensibleEnum = "1",
                floatExtensibleEnumCollection = new[] {
        "1"
    },
                floatFixedEnum = "1.1",
                floatFixedEnumCollection = new[] {
        "1.1"
    },
                intFixedEnum = "1",
                intFixedEnumCollection = new[] {
        "1"
    },
                stringFixedEnum = "1",
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
                optionalRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = await client.HelloAgainAsync("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("intFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("intFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("stringFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyOptionalRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloAgain_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var action = new RoundTripModel("<requiredString>", 1234, new StringFixedEnum[]
            {
    StringFixedEnum.One
            }, new Dictionary<string, StringExtensibleEnum>
            {
                ["key"] = StringExtensibleEnum.One,
            }, new Thing("<name>", "<requiredUnion>", "<requiredBadDescription>")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
                OptionalLiteralBool = true,
            }, BinaryData.FromString("<your binary data content>"), new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromString("<your binary data content>"),
            })
            {
                IntExtensibleEnum = IntExtensibleEnum.One,
                IntExtensibleEnumCollection =
{
        IntExtensibleEnum.One
    },
                FloatExtensibleEnum = FloatExtensibleEnum.One,
                FloatExtensibleEnumCollection =
{
        FloatExtensibleEnum.One
    },
                FloatFixedEnum = FloatFixedEnum.One,
                FloatFixedEnumCollection =
{
        FloatFixedEnum.One
    },
                IntFixedEnum = IntFixedEnum.One,
                IntFixedEnumCollection =
{
        IntFixedEnum.One
    },
                StringFixedEnum = StringFixedEnum.One,
                OptionalUnknown = BinaryData.FromString("<your binary data content>"),
                OptionalRecordUnknown =
{
        ["key"] = BinaryData.FromString("<your binary data content>"),
    },
            };
            var result = await client.HelloAgainAsync("<p2>", "<p1>", action);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoContentType()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                requiredUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = client.NoContentType("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoContentType_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                intExtensibleEnum = "1",
                intExtensibleEnumCollection = new[] {
        "1"
    },
                floatExtensibleEnum = "1",
                floatExtensibleEnumCollection = new[] {
        "1"
    },
                floatFixedEnum = "1.1",
                floatFixedEnumCollection = new[] {
        "1.1"
    },
                intFixedEnum = "1",
                intFixedEnumCollection = new[] {
        "1"
    },
                stringFixedEnum = "1",
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
                optionalRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = client.NoContentType("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("intFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("intFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("stringFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyOptionalRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoContentType_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                requiredUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = await client.NoContentTypeAsync("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoContentType_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
                requiredCollection = new[] {
        "1"
    },
                requiredDictionary = new
                {
                    key = "1",
                },
                requiredModel = new
                {
                    name = "<name>",
                    requiredUnion = new { },
                    requiredLiteralString = "accept",
                    requiredLiteralInt = 123,
                    requiredLiteralFloat = 1.23,
                    requiredLiteralBool = false,
                    optionalLiteralString = "reject",
                    optionalLiteralInt = 456,
                    optionalLiteralFloat = 4.56,
                    optionalLiteralBool = true,
                    requiredBadDescription = "<requiredBadDescription>",
                },
                intExtensibleEnum = "1",
                intExtensibleEnumCollection = new[] {
        "1"
    },
                floatExtensibleEnum = "1",
                floatExtensibleEnumCollection = new[] {
        "1"
    },
                floatFixedEnum = "1.1",
                floatFixedEnumCollection = new[] {
        "1.1"
    },
                intFixedEnum = "1",
                intFixedEnumCollection = new[] {
        "1"
    },
                stringFixedEnum = "1",
                requiredUnknown = new { },
                optionalUnknown = new { },
                requiredRecordUnknown = new
                {
                    key = new { },
                },
                optionalRecordUnknown = new
                {
                    key = new { },
                },
            };

            Response response = await client.NoContentTypeAsync("<p2>", "<p1>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredString").ToString());
            Console.WriteLine(result.GetProperty("requiredInt").ToString());
            Console.WriteLine(result.GetProperty("requiredCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredDictionary").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredModel").GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("intExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnum").ToString());
            Console.WriteLine(result.GetProperty("floatExtensibleEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("floatFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("intFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("intFixedEnumCollection")[0].ToString());
            Console.WriteLine(result.GetProperty("stringFixedEnum").ToString());
            Console.WriteLine(result.GetProperty("requiredUnknown").ToString());
            Console.WriteLine(result.GetProperty("optionalUnknown").ToString());
            Console.WriteLine(result.GetProperty("requiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("optionalRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyRequiredRecordUnknown").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("readOnlyOptionalRecordUnknown").GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloDemo2()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.HelloDemo2(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloDemo2_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.HelloDemo2(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloDemo2_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.HelloDemo2Async(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloDemo2_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.HelloDemo2Async(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloDemo2_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var result = await client.HelloDemo2Async();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateLiteral()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.CreateLiteral(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateLiteral_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = client.CreateLiteral(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateLiteral_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.CreateLiteralAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateLiteral_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
                requiredUnion = new { },
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
                requiredBadDescription = "<requiredBadDescription>",
            };

            Response response = await client.CreateLiteralAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateLiteral_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var body = new Thing("<name>", "<requiredUnion>", "<requiredBadDescription>")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
                OptionalLiteralBool = true,
            };
            var result = await client.CreateLiteralAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloLiteral()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.HelloLiteral(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HelloLiteral_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.HelloLiteral(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloLiteral_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.HelloLiteralAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloLiteral_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.HelloLiteralAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HelloLiteral_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var result = await client.HelloLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.GetUnknownValue();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = client.GetUnknownValue();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.GetUnknownValueAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            Response response = await client.GetUnknownValueAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InternalProtocol_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var body = new Thing("<name>", "<requiredUnion>", "<requiredBadDescription>")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
                OptionalLiteralBool = true,
            };
            var result = await client.InternalProtocolAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StillConvenient_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new FirstTestTypeSpecClient(endpoint);

            var result = await client.StillConvenientAsync();
        }
    }
}
