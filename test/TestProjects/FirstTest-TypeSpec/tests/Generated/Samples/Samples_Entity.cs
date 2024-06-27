// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace FirstTestTypeSpec.Samples
{
    public partial class Samples_Entity
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Entity_DoSomething_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response response = client.DoSomething("<p2>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredFloatProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Entity_DoSomething_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response response = await client.DoSomethingAsync("<p2>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("requiredNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredFloatProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Entity_DoSomething_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response<Thing> response = client.DoSomething("<p2>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Entity_DoSomething_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response<Thing> response = await client.DoSomethingAsync("<p2>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Entity_DoSomething_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response response = client.DoSomething("<p2>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("optionalNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredFloatProperty").ToString());
            Console.WriteLine(result.GetProperty("optionalFloatProperty").ToString());
            Console.WriteLine(result.GetProperty("embeddingVector")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Entity_DoSomething_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response response = await client.DoSomethingAsync("<p2>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("requiredUnion").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralString").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("requiredLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralString").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralInt").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralFloat").ToString());
            Console.WriteLine(result.GetProperty("optionalLiteralBool").ToString());
            Console.WriteLine(result.GetProperty("requiredBadDescription").ToString());
            Console.WriteLine(result.GetProperty("optionalNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredNullableList")[0].ToString());
            Console.WriteLine(result.GetProperty("requiredFloatProperty").ToString());
            Console.WriteLine(result.GetProperty("optionalFloatProperty").ToString());
            Console.WriteLine(result.GetProperty("embeddingVector")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Entity_DoSomething_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response<Thing> response = client.DoSomething("<p2>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Entity_DoSomething_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Entity client = new FirstTestTypeSpecClient(endpoint).GetEntityClient();

            Response<Thing> response = await client.DoSomethingAsync("<p2>");
        }
    }
}
