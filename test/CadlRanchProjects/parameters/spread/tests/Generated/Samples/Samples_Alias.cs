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
using NUnit.Framework;
using Parameters.Spread;

namespace Parameters.Spread.Samples
{
    internal class Samples_Alias
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestBody()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.SpreadAsRequestBody(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestBody_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.SpreadAsRequestBodyAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestBody_AllParameters()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.SpreadAsRequestBody(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestBody_AllParameters_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.SpreadAsRequestBodyAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestParameter()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.SpreadAsRequestParameter("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestParameter_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestParameter_AllParameters()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.SpreadAsRequestParameter("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestParameter_AllParameters_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadWithMultipleParameters()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["prop1"] = "<prop1>",
                ["prop2"] = "<prop2>",
                ["prop3"] = "<prop3>",
                ["prop4"] = "<prop4>",
                ["prop5"] = "<prop5>",
                ["prop6"] = "<prop6>",
            });
            Response response = client.SpreadWithMultipleParameters("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadWithMultipleParameters_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["prop1"] = "<prop1>",
                ["prop2"] = "<prop2>",
                ["prop3"] = "<prop3>",
                ["prop4"] = "<prop4>",
                ["prop5"] = "<prop5>",
                ["prop6"] = "<prop6>",
            });
            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadWithMultipleParameters_AllParameters()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["prop1"] = "<prop1>",
                ["prop2"] = "<prop2>",
                ["prop3"] = "<prop3>",
                ["prop4"] = "<prop4>",
                ["prop5"] = "<prop5>",
                ["prop6"] = "<prop6>",
            });
            Response response = client.SpreadWithMultipleParameters("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadWithMultipleParameters_AllParameters_Async()
        {
            Alias client = new SpreadClient().GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["prop1"] = "<prop1>",
                ["prop2"] = "<prop2>",
                ["prop3"] = "<prop3>",
                ["prop4"] = "<prop4>",
                ["prop5"] = "<prop5>",
                ["prop6"] = "<prop6>",
            });
            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", content);
            Console.WriteLine(response.Status);
        }
    }
}
