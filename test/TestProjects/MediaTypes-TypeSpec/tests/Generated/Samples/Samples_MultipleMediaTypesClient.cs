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
using MultipleMediaTypes.Models;
using NUnit.Framework;

namespace MultipleMediaTypes.Samples
{
    public class Samples_MultipleMediaTypesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneBinaryBodyTwoContentTypes()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new { };

            Response response = client.OneBinaryBodyTwoContentTypes(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneBinaryBodyTwoContentTypes_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new { };

            Response response = client.OneBinaryBodyTwoContentTypes(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneBinaryBodyTwoContentTypes_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new { };

            Response response = await client.OneBinaryBodyTwoContentTypesAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneBinaryBodyTwoContentTypes_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new { };

            Response response = await client.OneBinaryBodyTwoContentTypesAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneBinaryBodyTwoContentTypes_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var body = BinaryData.FromString("<your binary data content>");
            var result = await client.OneBinaryBodyTwoContentTypesAsync(body, ContentType.ApplicationOctetStream);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneStringBodyThreeContentTypes()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = "<String>";

            Response response = client.OneStringBodyThreeContentTypes(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneStringBodyThreeContentTypes_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = "<String>";

            Response response = client.OneStringBodyThreeContentTypes(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneStringBodyThreeContentTypes_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = "<String>";

            Response response = await client.OneStringBodyThreeContentTypesAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneStringBodyThreeContentTypes_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = "<String>";

            Response response = await client.OneStringBodyThreeContentTypesAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneStringBodyThreeContentTypes_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var body = "<null>";
            var result = await client.OneStringBodyThreeContentTypesAsync(body, ContentType.ApplicationOctetStream);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneModelBodyOneContentType()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new
            {
                id = "<id>",
            };

            Response response = client.OneModelBodyOneContentType(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OneModelBodyOneContentType_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new
            {
                id = "<id>",
            };

            Response response = client.OneModelBodyOneContentType(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneModelBodyOneContentType_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.OneModelBodyOneContentTypeAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneModelBodyOneContentType_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.OneModelBodyOneContentTypeAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OneModelBodyOneContentType_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleMediaTypesClient(endpoint);

            var body = new Body("<id>");
            var result = await client.OneModelBodyOneContentTypeAsync(body);
        }
    }
}
