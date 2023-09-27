// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using SpreadTypeSpec;
using SpreadTypeSpec.Models;

namespace SpreadTypeSpec.Samples
{
    public partial class Samples_SpreadTypeSpecClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadModel()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadModel_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = client.SpreadModel(thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = await client.SpreadModelAsync(thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadModel_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = client.SpreadModel(thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadModel_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = await client.SpreadModelAsync(thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAlias()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAlias(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAlias_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAlias("<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasAsync("<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAlias_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAlias(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAlias_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAlias("<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAlias_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasAsync("<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadMultiTargetAlias()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadMultiTargetAlias("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadMultiTargetAlias_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadMultiTargetAlias("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadMultiTargetAlias_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadMultiTargetAlias("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadMultiTargetAlias_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadMultiTargetAlias("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadMultiTargetAlias_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadMultiTargetAliasAsync("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithModel()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAliasWithModel("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithModel_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = client.SpreadAliasWithModel("<id>", 1234, thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAliasWithModel("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithModel_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = client.SpreadAliasWithModel("<id>", 1234, thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithModel_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>", 1234);
            Response response = await client.SpreadAliasWithModelAsync("<id>", 1234, thing);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithSpreadAlias()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAliasWithSpreadAlias("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithSpreadAlias_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithSpreadAlias("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithSpreadAlias_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.SpreadAliasWithSpreadAlias("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithSpreadAlias_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithSpreadAlias("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithSpreadAlias_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithSpreadAliasAsync("<id>", 1234, "<name>", 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                items = new object[]
            {
1234
            },
            });
            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                items = new object[]
            {
1234
            },
            });
            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, "<name>", new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, "<name>", new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                color = "<color>",
                age = 1234,
                items = new object[]
            {
1234
            },
                elements = new object[]
            {
"<elements>"
            },
            });
            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                color = "<color>",
                age = 1234,
                items = new object[]
            {
1234
            },
                elements = new object[]
            {
"<elements>"
            },
            });
            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithOptionalProps_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithOptionalProps("<id>", 1234, "<name>", new int[] { 1234 }, color: "<color>", age: 1234, elements: new string[] { "<elements>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithOptionalProps_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithOptionalPropsAsync("<id>", 1234, "<name>", new int[] { 1234 }, color: "<color>", age: 1234, elements: new string[] { "<elements>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithCollections()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredStringList = new object[]
            {
"<requiredStringList>"
            },
            });
            Response response = client.SpreadAliasWithCollections(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithCollections_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredStringList = new object[]
            {
"<requiredStringList>"
            },
            });
            Response response = await client.SpreadAliasWithCollectionsAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithCollections_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithCollections(new string[] { "<requiredStringList>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithCollections_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithCollectionsAsync(new string[] { "<requiredStringList>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithCollections_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredStringList = new object[]
            {
"<requiredStringList>"
            },
                optionalStringList = new object[]
            {
"<optionalStringList>"
            },
            });
            Response response = client.SpreadAliasWithCollections(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithCollections_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredStringList = new object[]
            {
"<requiredStringList>"
            },
                optionalStringList = new object[]
            {
"<optionalStringList>"
            },
            });
            Response response = await client.SpreadAliasWithCollectionsAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadAliasWithCollections_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = client.SpreadAliasWithCollections(new string[] { "<requiredStringList>" }, optionalStringList: new string[] { "<optionalStringList>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadAliasWithCollections_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SpreadTypeSpecClient client = new SpreadTypeSpecClient(endpoint);

            Response response = await client.SpreadAliasWithCollectionsAsync(new string[] { "<requiredStringList>" }, optionalStringList: new string[] { "<optionalStringList>" });
        }
    }
}
