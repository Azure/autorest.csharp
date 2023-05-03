// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Spread.Samples
{
    public class Samples_SpreadClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadModel()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.SpreadModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAlias()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.SpreadAlias(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadMultiTargetAlias()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.SpreadMultiTargetAlias("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithModel()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.SpreadAliasWithModel("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithSpreadAlias()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.SpreadAliasWithSpreadAlias("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                items = new[] {
        1234
    },
            };

            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
