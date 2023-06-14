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
using _Type.Property.Optional.Models;

namespace _Type.Property.Optional.Samples
{
    internal class Samples_RequiredAndOptional
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = client.GetAll(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = client.GetAll(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = await client.GetAllAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = await client.GetAllAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Convenience_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var result = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequiredOnly()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = client.GetRequiredOnly(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequiredOnly_AllParameters()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = client.GetRequiredOnly(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequiredOnly_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = await client.GetRequiredOnlyAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequiredOnly_AllParameters_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            Response response = await client.GetRequiredOnlyAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("optionalProperty").ToString());
            Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequiredOnly_Convenience_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var result = await client.GetRequiredOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                requiredProperty = 1234,
            };

            Response response = client.PutAll(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                optionalProperty = "<optionalProperty>",
                requiredProperty = 1234,
            };

            Response response = client.PutAll(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                requiredProperty = 1234,
            };

            Response response = await client.PutAllAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                optionalProperty = "<optionalProperty>",
                requiredProperty = 1234,
            };

            Response response = await client.PutAllAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Convenience_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var body = new RequiredAndOptionalProperty(1234)
            {
                OptionalProperty = "<OptionalProperty>",
            };
            var result = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOnly()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                requiredProperty = 1234,
            };

            Response response = client.PutRequiredOnly(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOnly_AllParameters()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                optionalProperty = "<optionalProperty>",
                requiredProperty = 1234,
            };

            Response response = client.PutRequiredOnly(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOnly_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                requiredProperty = 1234,
            };

            Response response = await client.PutRequiredOnlyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOnly_AllParameters_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var data = new
            {
                optionalProperty = "<optionalProperty>",
                requiredProperty = 1234,
            };

            Response response = await client.PutRequiredOnlyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOnly_Convenience_Async()
        {
            var client = new OptionalClient().GetRequiredAndOptionalClient("1.0.0");

            var body = new RequiredAndOptionalProperty(1234)
            {
                OptionalProperty = "<OptionalProperty>",
            };
            var result = await client.PutRequiredOnlyAsync(body);
        }
    }
}
