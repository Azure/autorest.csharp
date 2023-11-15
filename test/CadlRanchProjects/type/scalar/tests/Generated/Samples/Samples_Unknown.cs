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
using _Type.Scalar;

namespace _Type.Scalar.Samples
{
    public partial class Samples_Unknown
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknown_ShortVersion()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = client.GetUnknown(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknown_ShortVersion_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = await client.GetUnknownAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknown_ShortVersion_Convenience()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response<BinaryData> response = client.GetUnknown();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknown_ShortVersion_Convenience_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response<BinaryData> response = await client.GetUnknownAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknown_AllParameters()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = client.GetUnknown(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknown_AllParameters_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = await client.GetUnknownAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknown_AllParameters_Convenience()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response<BinaryData> response = client.GetUnknown();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknown_AllParameters_Convenience_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response<BinaryData> response = await client.GetUnknownAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = client.Put(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = await client.PutAsync(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = client.Put(BinaryData.FromObjectAsJson(new object()));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Unknown client = new ScalarClient().GetUnknownClient();

            Response response = await client.PutAsync(BinaryData.FromObjectAsJson(new object()));
        }
    }
}
