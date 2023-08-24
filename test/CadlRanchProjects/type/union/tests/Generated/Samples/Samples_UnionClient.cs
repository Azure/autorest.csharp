// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

namespace _Type.Union.Samples
{
    public class Samples_UnionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = client.SendInt(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_AllParameters()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = client.SendInt(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = await client.SendIntAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_AllParameters_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = await client.SendIntAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = client.SendIntArray(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_AllParameters()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = client.SendIntArray(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = await client.SendIntArrayAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_AllParameters_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                simpleUnion = new { },
            };

            Response response = await client.SendIntArrayAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = client.SendFirstNamedUnionValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_AllParameters()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = client.SendFirstNamedUnionValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = await client.SendFirstNamedUnionValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_AllParameters_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = await client.SendFirstNamedUnionValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = client.SendSecondNamedUnionValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_AllParameters()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = client.SendSecondNamedUnionValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = await client.SendSecondNamedUnionValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_AllParameters_Async()
        {
            var client = new UnionClient();

            var data = new
            {
                namedUnion = new { },
            };

            Response response = await client.SendSecondNamedUnionValueAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
