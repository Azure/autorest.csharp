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
using _Type.Property.AdditionalProperties;
using _Type.Property.AdditionalProperties.Models;

namespace _Type.Property.AdditionalProperties.Samples
{
    public partial class Samples_IsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_GetIsModel_ShortVersion()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response response = client.GetIsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_GetIsModel_ShortVersion_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetIsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_GetIsModel_ShortVersion_Convenience()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response<IsModelAdditionalProperties> response = client.GetIsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_GetIsModel_ShortVersion_Convenience_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response<IsModelAdditionalProperties> response = await client.GetIsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_GetIsModel_AllParameters()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response response = client.GetIsModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_GetIsModel_AllParameters_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetIsModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_GetIsModel_AllParameters_Convenience()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response<IsModelAdditionalProperties> response = client.GetIsModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_GetIsModel_AllParameters_Convenience_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            Response<IsModelAdditionalProperties> response = await client.GetIsModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_Put_ShortVersion()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_Put_ShortVersion_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_Put_ShortVersion_Convenience()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            IsModelAdditionalProperties body = new IsModelAdditionalProperties();
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_Put_ShortVersion_Convenience_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            IsModelAdditionalProperties body = new IsModelAdditionalProperties();
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_Put_AllParameters()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_Put_AllParameters_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsModel_Put_AllParameters_Convenience()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            IsModelAdditionalProperties body = new IsModelAdditionalProperties();
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsModel_Put_AllParameters_Convenience_Async()
        {
            IsModel client = new AdditionalPropertiesClient().GetIsModelClient(apiVersion: "1.0.0");

            IsModelAdditionalProperties body = new IsModelAdditionalProperties();
            Response response = await client.PutAsync(body);
        }
    }
}
