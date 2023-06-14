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
    internal class Samples_Model
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAsRequestBody()
        {
            var client = new SpreadClient().GetModelClient("1.0.0");

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
            var client = new SpreadClient().GetModelClient("1.0.0");

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
            var client = new SpreadClient().GetModelClient("1.0.0");

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
            var client = new SpreadClient().GetModelClient("1.0.0");

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
            var client = new SpreadClient().GetModelClient("1.0.0");

            var bodyParameter = new BodyParameter("<name>");
            var result = await client.SpreadAsRequestBodyAsync(bodyParameter);
        }
    }
}
