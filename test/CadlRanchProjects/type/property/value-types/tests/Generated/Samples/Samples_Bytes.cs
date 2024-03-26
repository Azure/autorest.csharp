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
    public partial class Samples_Bytes
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetByte_ShortVersion()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response response = client.GetByte(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetByte_ShortVersion_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response response = await client.GetByteAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetByte_ShortVersion_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response<BytesProperty> response = client.GetByte();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetByte_ShortVersion_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetByteAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetByte_AllParameters()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response response = client.GetByte(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetByte_AllParameters_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response response = await client.GetByteAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_GetByte_AllParameters_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response<BytesProperty> response = client.GetByte();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_GetByte_AllParameters_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            Response<BytesProperty> response = await client.GetByteAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_Put_ShortVersion()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_Put_ShortVersion_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_Put_ShortVersion_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_Put_ShortVersion_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_Put_AllParameters()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_Put_AllParameters_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Bytes_Put_AllParameters_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Bytes_Put_AllParameters_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient();

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
