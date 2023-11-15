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
using _Type._Array;

namespace _Type._Array.Samples
{
    public partial class Samples_Float32Value
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_ShortVersion()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = client.GetFloat32Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_ShortVersion_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = await client.GetFloat32ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_ShortVersion_Convenience()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response<IReadOnlyList<float>> response = client.GetFloat32Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_ShortVersion_Convenience_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response<IReadOnlyList<float>> response = await client.GetFloat32ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_AllParameters()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = client.GetFloat32Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_AllParameters_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = await client.GetFloat32ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_AllParameters_Convenience()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response<IReadOnlyList<float>> response = client.GetFloat32Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_AllParameters_Convenience_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response<IReadOnlyList<float>> response = await client.GetFloat32ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
123.45F
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
123.45F
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = client.Put(new float[] { 123.45F });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = await client.PutAsync(new float[] { 123.45F });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
123.45F
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
123.45F
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = client.Put(new float[] { 123.45F });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Float32Value client = new ArrayClient().GetFloat32ValueClient();

            Response response = await client.PutAsync(new float[] { 123.45F });
        }
    }
}
