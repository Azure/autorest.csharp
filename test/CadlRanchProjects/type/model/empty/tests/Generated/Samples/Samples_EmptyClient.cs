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
using _Type.Model.Empty.Models;

namespace _Type.Model.Empty.Samples
{
    public class Samples_EmptyClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty_AllParameters()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_Async()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_AllParameters_Async()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_Convenience_Async()
        {
            var client = new EmptyClient();

            var input = new EmptyInput();
            var result = await client.PutEmptyAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty()
        {
            var client = new EmptyClient();

            Response response = client.GetEmpty(new RequestContext());

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty_AllParameters()
        {
            var client = new EmptyClient();

            Response response = client.GetEmpty(new RequestContext());

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Async()
        {
            var client = new EmptyClient();

            Response response = await client.GetEmptyAsync(new RequestContext());

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_AllParameters_Async()
        {
            var client = new EmptyClient();

            Response response = await client.GetEmptyAsync(new RequestContext());

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Convenience_Async()
        {
            var client = new EmptyClient();

            var result = await client.GetEmptyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostRoundTripEmpty()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = client.PostRoundTripEmpty(RequestContent.Create(data));

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostRoundTripEmpty_AllParameters()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = client.PostRoundTripEmpty(RequestContent.Create(data));

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostRoundTripEmpty_Async()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = await client.PostRoundTripEmptyAsync(RequestContent.Create(data));

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostRoundTripEmpty_AllParameters_Async()
        {
            var client = new EmptyClient();

            var data = new { };

            Response response = await client.PostRoundTripEmptyAsync(RequestContent.Create(data));

            Console.WriteLine(response.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostRoundTripEmpty_Convenience_Async()
        {
            var client = new EmptyClient();

            var body = new EmptyInputOutput();
            var result = await client.PostRoundTripEmptyAsync(body);
        }
    }
}
