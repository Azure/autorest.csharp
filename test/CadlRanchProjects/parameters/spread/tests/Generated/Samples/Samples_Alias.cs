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
using NUnit.Framework;
using Parameters.Spread.Models;

namespace Parameters.Spread.Samples
{
    internal class Samples_Alias
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestBody()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = client.SpreadAsRequestBody(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestBody_AllParameters()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = client.SpreadAsRequestBody(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestBody_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.SpreadAsRequestBodyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestBody_AllParameters_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.SpreadAsRequestBodyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestBody_Convenience_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var result = await client.SpreadAsRequestBodyAsync("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestParameter()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = client.SpreadAsRequestParameter("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestParameter_AllParameters()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = client.SpreadAsRequestParameter("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestParameter_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestParameter_AllParameters_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAsRequestParameter_Convenience_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var result = await client.SpreadAsRequestParameterAsync("<id>", "<xMsTestHeader>", "<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadWithMultipleParameters()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            };

            Response response = client.SpreadWithMultipleParameters("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadWithMultipleParameters_AllParameters()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            };

            Response response = client.SpreadWithMultipleParameters("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadWithMultipleParameters_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            };

            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadWithMultipleParameters_AllParameters_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var data = new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            };

            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<xMsTestHeader>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadWithMultipleParameters_Convenience_Async()
        {
            var client = new SpreadClient().GetAliasClient("1.0.0");

            var result = await client.SpreadWithMultipleParametersAsync("<id>", "<xMsTestHeader>", "<prop1>", "<prop2>", "<prop3>", "<prop4>", "<prop5>", "<prop6>");
        }
    }
}
