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
    public partial class Samples_UnknownDict
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_GetUnknownDict_ShortVersion()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownDict(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_GetUnknownDict_ShortVersion_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownDictAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_GetUnknownDict_ShortVersion_Convenience()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response<UnknownDictProperty> response = client.GetUnknownDict();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_GetUnknownDict_ShortVersion_Convenience_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response<UnknownDictProperty> response = await client.GetUnknownDictAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_GetUnknownDict_AllParameters()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response response = client.GetUnknownDict(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_GetUnknownDict_AllParameters_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownDictAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_GetUnknownDict_AllParameters_Convenience()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response<UnknownDictProperty> response = client.GetUnknownDict();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_GetUnknownDict_AllParameters_Convenience_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            Response<UnknownDictProperty> response = await client.GetUnknownDictAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_Put_ShortVersion()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_Put_ShortVersion_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_Put_ShortVersion_Convenience()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            UnknownDictProperty body = new UnknownDictProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_Put_ShortVersion_Convenience_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            UnknownDictProperty body = new UnknownDictProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_Put_AllParameters()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_Put_AllParameters_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnknownDict_Put_AllParameters_Convenience()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            UnknownDictProperty body = new UnknownDictProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnknownDict_Put_AllParameters_Convenience_Async()
        {
            UnknownDict client = new ValueTypesClient().GetUnknownDictClient(apiVersion: "1.0.0");

            UnknownDictProperty body = new UnknownDictProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
