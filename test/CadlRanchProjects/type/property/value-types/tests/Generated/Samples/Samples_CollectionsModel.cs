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
    public class Samples_CollectionsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetCollectionsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetCollectionsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetCollectionsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetCollectionsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel_AllParameters()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetCollectionsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_AllParameters_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetCollectionsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionsModel_AllParameters_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetCollectionsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionsModel_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetCollectionsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
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
        public async Task Example_Put_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
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
        public void Example_Put_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
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
        public async Task Example_Put_AllParameters_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
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
        public void Example_Put_AllParameters_Convenience()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new ValueTypesClient().GetCollectionsModelClient("1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty(new InnerModel[]
            {
new InnerModel("<property>")
            });
            Response response = await client.PutAsync(body);
        }
    }
}
