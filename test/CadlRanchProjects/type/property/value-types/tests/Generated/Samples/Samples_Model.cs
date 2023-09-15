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
    internal class Samples_Model
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response<ModelProperty> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response<ModelProperty> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response<ModelProperty> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            Response<ModelProperty> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new
                {
                    property = "<property>",
                },
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new
                {
                    property = "<property>",
                },
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new
                {
                    property = "<property>",
                },
            });
            Response response = client.Put(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new
                {
                    property = "<property>",
                },
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = client.Put(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient(apiVersion: "1.0.0");

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
