// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using SpecialWords;
using SpecialWords.Models;

namespace SpecialWords.Samples
{
    public class Samples_Model
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response response = client.GetModel();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("model.kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response response = await client.GetModelAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("model.kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_Convenience()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response<BaseModel> response = client.GetModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Convenience_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response<BaseModel> response = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response response = client.GetModel();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("model.kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response response = await client.GetModelAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("model.kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_AllParameters_Convenience()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response<BaseModel> response = client.GetModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_AllParameters_Convenience_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            Response<BaseModel> response = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["derived.name"] = "<derived.name>",
                ["for"] = "<for>",
                ["model.kind"] = "derived"
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["derived.name"] = "<derived.name>",
                ["for"] = "<for>",
                ["model.kind"] = "derived"
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            BaseModel body = new DerivedModel("<derived.name>", "<for>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            BaseModel body = new DerivedModel("<derived.name>", "<for>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["derived.name"] = "<derived.name>",
                ["for"] = "<for>",
                ["model.kind"] = "derived"
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["derived.name"] = "<derived.name>",
                ["for"] = "<for>",
                ["model.kind"] = "derived"
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            BaseModel body = new DerivedModel("<derived.name>", "<for>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Model client = new SpecialWordsClient().GetModelClient(apiVersion: "1.0.0");

            BaseModel body = new DerivedModel("<derived.name>", "<for>");
            Response response = await client.PutAsync(body);
        }
    }
}
