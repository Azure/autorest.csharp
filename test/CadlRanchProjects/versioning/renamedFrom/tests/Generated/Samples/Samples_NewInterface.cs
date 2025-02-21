// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Versioning.RenamedFrom.Models;

namespace Versioning.RenamedFrom.Samples
{
    public partial class Samples_NewInterface
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NewInterface_NewOpInNewInterface_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            using RequestContent content = RequestContent.Create(new
            {
                newProp = "<newProp>",
                enumProp = "newEnumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.NewOpInNewInterface(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("newProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NewInterface_NewOpInNewInterface_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            using RequestContent content = RequestContent.Create(new
            {
                newProp = "<newProp>",
                enumProp = "newEnumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.NewOpInNewInterfaceAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("newProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NewInterface_NewOpInNewInterface_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            NewModel body = new NewModel("<newProp>", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<NewModel> response = client.NewOpInNewInterface(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NewInterface_NewOpInNewInterface_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            NewModel body = new NewModel("<newProp>", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<NewModel> response = await client.NewOpInNewInterfaceAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NewInterface_NewOpInNewInterface_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            using RequestContent content = RequestContent.Create(new
            {
                newProp = "<newProp>",
                enumProp = "newEnumMember",
                unionProp = "<unionProp>",
            });
            Response response = client.NewOpInNewInterface(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("newProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NewInterface_NewOpInNewInterface_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            using RequestContent content = RequestContent.Create(new
            {
                newProp = "<newProp>",
                enumProp = "newEnumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.NewOpInNewInterfaceAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("newProp").ToString());
            Console.WriteLine(result.GetProperty("enumProp").ToString());
            Console.WriteLine(result.GetProperty("unionProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NewInterface_NewOpInNewInterface_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            NewModel body = new NewModel("<newProp>", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<NewModel> response = client.NewOpInNewInterface(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NewInterface_NewOpInNewInterface_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NewInterface client = new RenamedFromClient(endpoint, default).GetNewInterfaceClient();

            NewModel body = new NewModel("<newProp>", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<NewModel> response = await client.NewOpInNewInterfaceAsync(body);
        }
    }
}
