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
using _Type.Union;

namespace _Type.Union.Samples
{
    public partial class Samples_UnionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendInt(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendInt(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendIntArray(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntArrayAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendIntArray(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntArrayAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendFirstNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendFirstNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendFirstNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendFirstNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendSecondNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendSecondNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendSecondNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendSecondNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveIntArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveIntArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveIntArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveIntArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveFirstNamedUnionValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveFirstNamedUnionValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveFirstNamedUnionValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveFirstNamedUnionValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveSecondNamedUnionValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveSecondNamedUnionValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveSecondNamedUnionValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveSecondNamedUnionValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("namedUnion").ToString());
        }
    }
}
