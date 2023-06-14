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
using Spread.Models;

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
        public void Example_SpreadModel_AllParameters()
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
        public async Task Example_SpreadModel_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var thing = new Thing("<name>", 1234);
            var result = await client.SpreadModelAsync(thing);
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
        public void Example_SpreadAlias_AllParameters()
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
        public async Task Example_SpreadAlias_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var result = await client.SpreadAliasAsync("<name>", 1234);
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
        public void Example_SpreadMultiTargetAlias_AllParameters()
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
        public async Task Example_SpreadMultiTargetAlias_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var result = await client.SpreadMultiTargetAliasAsync("<id>", 1234, "<name>", 1234);
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
        public void Example_SpreadAliasWithModel_AllParameters()
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
        public async Task Example_SpreadAliasWithModel_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var thing = new Thing("<name>", 1234);
            var result = await client.SpreadAliasWithModelAsync("<id>", 1234, thing);
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
        public void Example_SpreadAliasWithSpreadAlias_AllParameters()
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
        public async Task Example_SpreadAliasWithSpreadAlias_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var result = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, "<name>", 1234);
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

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                color = "<color>",
                age = 1234,
                items = new[] {
        1234
    },
                elements = new[] {
        "<String>"
    },
            };

            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_Async()
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

            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var data = new
            {
                name = "<name>",
                color = "<color>",
                age = 1234,
                items = new[] {
        1234
    },
                elements = new[] {
        "<String>"
    },
            };

            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SpreadClient(endpoint);

            var result = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, "<name>", new int[] { 1234 }, "<color>", 1234, new string[] { "<elements>" });
        }
    }
}
