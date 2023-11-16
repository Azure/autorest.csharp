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
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public partial class Samples_CollectionsString
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsString_ShortVersion()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response response = client.GetCollectionsString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsString_ShortVersion_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response response = await client.GetCollectionsStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsString_ShortVersion_Convenience()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response<CollectionsStringProperty> response = client.GetCollectionsString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsString_ShortVersion_Convenience_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response<CollectionsStringProperty> response = await client.GetCollectionsStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsString_AllParameters()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response response = client.GetCollectionsString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsString_AllParameters_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response response = await client.GetCollectionsStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsString_AllParameters_Convenience()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response<CollectionsStringProperty> response = client.GetCollectionsString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsString_AllParameters_Convenience_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            Response<CollectionsStringProperty> response = await client.GetCollectionsStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
"<property>"
            },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
"<property>"
            },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            CollectionsStringProperty body = new CollectionsStringProperty(new string[] { "<property>" });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            CollectionsStringProperty body = new CollectionsStringProperty(new string[] { "<property>" });
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
"<property>"
            },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
"<property>"
            },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            CollectionsStringProperty body = new CollectionsStringProperty(new string[] { "<property>" });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            CollectionsString client = new ValueTypesClient().GetCollectionsStringClient();

            CollectionsStringProperty body = new CollectionsStringProperty(new string[] { "<property>" });
            Response response = await client.PutAsync(body);
        }
    }
}
