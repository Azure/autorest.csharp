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
    public partial class Samples_CollectionsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_GetCollectionsModel_ShortVersion()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response response = client.GetCollectionsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_GetCollectionsModel_ShortVersion_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response response = await client.GetCollectionsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_GetCollectionsModel_ShortVersion_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response<CollectionsModelProperty> response = client.GetCollectionsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_GetCollectionsModel_ShortVersion_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response<CollectionsModelProperty> response = await client.GetCollectionsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_GetCollectionsModel_AllParameters()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response response = client.GetCollectionsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_GetCollectionsModel_AllParameters_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response response = await client.GetCollectionsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_GetCollectionsModel_AllParameters_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response<CollectionsModelProperty> response = client.GetCollectionsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_GetCollectionsModel_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            Response<CollectionsModelProperty> response = await client.GetCollectionsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_Put_ShortVersion()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_Put_ShortVersion_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_Put_ShortVersion_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_Put_ShortVersion_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_Put_AllParameters()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_Put_AllParameters_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsModel_Put_AllParameters_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsModel_Put_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient();

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = await client.PutAsync(body);
        }
    }
}
