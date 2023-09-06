// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    internal class Samples_CollectionsInt
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsInt()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response response = client.GetCollectionsInt(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsInt_AllParameters()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response response = client.GetCollectionsInt(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsInt_Convenience()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response<CollectionsIntProperty> response = client.GetCollectionsInt();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsInt_AllParameters_Convenience()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response<CollectionsIntProperty> response = client.GetCollectionsInt();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsInt_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response response = await client.GetCollectionsIntAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsInt_AllParameters_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response response = await client.GetCollectionsIntAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsInt_Convenience_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response<CollectionsIntProperty> response = await client.GetCollectionsIntAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsInt_AllParameters_Convenience_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            Response<CollectionsIntProperty> response = await client.GetCollectionsIntAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = new object[]
            {
1234
            },
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = new object[]
            {
1234
            },
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            CollectionsIntProperty body = new CollectionsIntProperty(new int[]
            {
1234
            });
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            CollectionsIntProperty body = new CollectionsIntProperty(new int[]
            {
1234
            });
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = new object[]
            {
1234
            },
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["property"] = new object[]
            {
1234
            },
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            CollectionsIntProperty body = new CollectionsIntProperty(new int[]
            {
1234
            });
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            CollectionsInt client = new ValueTypesClient().GetCollectionsIntClient(apiVersion: "1.0.0");

            CollectionsIntProperty body = new CollectionsIntProperty(new int[]
            {
1234
            });
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
