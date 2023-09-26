// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public class Samples_Bytes
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response response = client.GetByte(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response response = await client.GetByteAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response<BytesProperty> response = client.GetByte();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response<BytesProperty> response = await client.GetByteAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte_AllParameters()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response response = client.GetByte(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_AllParameters_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response response = await client.GetByteAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte_AllParameters_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response<BytesProperty> response = client.GetByte();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_AllParameters_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            Response<BytesProperty> response = await client.GetByteAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = client.Put(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Bytes client = new ValueTypesClient().GetBytesClient("1.0.0");

            BytesProperty body = new BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
