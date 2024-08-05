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

namespace _Type.Scalar.Samples
{
    public partial class Samples_Decimal128Type
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_ResponseBody_ShortVersion()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.ResponseBody(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_ResponseBody_ShortVersion_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.ResponseBodyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_ResponseBody_ShortVersion_Convenience()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response<decimal> response = client.ResponseBody();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_ResponseBody_ShortVersion_Convenience_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response<decimal> response = await client.ResponseBodyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_ResponseBody_AllParameters()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.ResponseBody(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_ResponseBody_AllParameters_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.ResponseBodyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_ResponseBody_AllParameters_Convenience()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response<decimal> response = client.ResponseBody();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_ResponseBody_AllParameters_Convenience_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response<decimal> response = await client.ResponseBodyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestBody_ShortVersion()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            using RequestContent content = RequestContent.Create(123.45M);
            Response response = client.RequestBody(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestBody_ShortVersion_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            using RequestContent content = RequestContent.Create(123.45M);
            Response response = await client.RequestBodyAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestBody_ShortVersion_Convenience()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.RequestBody(123.45M);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestBody_ShortVersion_Convenience_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.RequestBodyAsync(123.45M);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestBody_AllParameters()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            using RequestContent content = RequestContent.Create(123.45M);
            Response response = client.RequestBody(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestBody_AllParameters_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            using RequestContent content = RequestContent.Create(123.45M);
            Response response = await client.RequestBodyAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestBody_AllParameters_Convenience()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.RequestBody(123.45M);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestBody_AllParameters_Convenience_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.RequestBodyAsync(123.45M);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestParameter_ShortVersion()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.RequestParameter(123.45M);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestParameter_ShortVersion_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.RequestParameterAsync(123.45M);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Decimal128Type_RequestParameter_AllParameters()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = client.RequestParameter(123.45M);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Decimal128Type_RequestParameter_AllParameters_Async()
        {
            Decimal128Type client = new ScalarClient().GetDecimal128TypeClient();

            Response response = await client.RequestParameterAsync(123.45M);

            Console.WriteLine(response.Status);
        }
    }
}
