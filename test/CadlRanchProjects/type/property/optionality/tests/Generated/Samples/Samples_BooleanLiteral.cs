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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public partial class Samples_BooleanLiteral
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetAll_ShortVersion()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetAll_ShortVersion_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetAll_ShortVersion_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetAll_ShortVersion_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetAll_AllParameters()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetAll_AllParameters_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetAll_AllParameters_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetAll_AllParameters_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetDefault_ShortVersion()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetDefault_ShortVersion_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetDefault_ShortVersion_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetDefault_ShortVersion_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetDefault_AllParameters()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetDefault_AllParameters_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_GetDefault_AllParameters_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_GetDefault_AllParameters_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            Response<BooleanLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutAll_ShortVersion()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutAll_ShortVersion_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutAll_ShortVersion_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutAll_ShortVersion_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutAll_AllParameters()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutAll_AllParameters_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutAll_AllParameters_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutAll_AllParameters_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutDefault_ShortVersion()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutDefault_ShortVersion_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutDefault_ShortVersion_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutDefault_ShortVersion_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutDefault_AllParameters()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutDefault_AllParameters_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BooleanLiteral_PutDefault_AllParameters_Convenience()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BooleanLiteral_PutDefault_AllParameters_Convenience_Async()
        {
            BooleanLiteral client = new OptionalClient().GetBooleanLiteralClient(apiVersion: "1.0.0");

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
