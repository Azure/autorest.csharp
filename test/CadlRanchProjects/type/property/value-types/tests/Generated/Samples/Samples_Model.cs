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
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public partial class Samples_Model
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_GetModel_ShortVersion()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_GetModel_ShortVersion_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_GetModel_ShortVersion_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response<ModelProperty> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_GetModel_ShortVersion_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response<ModelProperty> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_GetModel_AllParameters()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response response = client.GetModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_GetModel_AllParameters_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response response = await client.GetModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_GetModel_AllParameters_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response<ModelProperty> response = client.GetModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_GetModel_AllParameters_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            Response<ModelProperty> response = await client.GetModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_Put_ShortVersion()
        {
            Model client = new ValueTypesClient().GetModelClient();

            using RequestContent content = RequestContent.Create(new
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
        public async Task Example_Model_Put_ShortVersion_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            using RequestContent content = RequestContent.Create(new
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
        public void Example_Model_Put_ShortVersion_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient();

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_Put_ShortVersion_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Model_Put_AllParameters()
        {
            Model client = new ValueTypesClient().GetModelClient();

            using RequestContent content = RequestContent.Create(new
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
        public async Task Example_Model_Put_AllParameters_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            using RequestContent content = RequestContent.Create(new
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
        public void Example_Model_Put_AllParameters_Convenience()
        {
            Model client = new ValueTypesClient().GetModelClient();

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Model_Put_AllParameters_Convenience_Async()
        {
            Model client = new ValueTypesClient().GetModelClient();

            ModelProperty body = new ModelProperty(new InnerModel("<property>"));
            Response response = await client.PutAsync(body);
        }
    }
}
