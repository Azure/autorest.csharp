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
    public partial class Samples_Boolean
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean_ShortVersion()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = client.GetBoolean(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_ShortVersion_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = await client.GetBooleanAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean_ShortVersion_Convenience()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response<bool> response = client.GetBoolean();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_ShortVersion_Convenience_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response<bool> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean_AllParameters()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = client.GetBoolean(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_AllParameters_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = await client.GetBooleanAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBoolean_AllParameters_Convenience()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response<bool> response = client.GetBoolean();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBoolean_AllParameters_Convenience_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response<bool> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            using RequestContent content = RequestContent.Create(true);
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            using RequestContent content = RequestContent.Create(true);
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = client.Put(true);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = await client.PutAsync(true);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            using RequestContent content = RequestContent.Create(true);
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            using RequestContent content = RequestContent.Create(true);
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = client.Put(true);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Boolean client = new ScalarClient().GetBooleanClient();

            Response response = await client.PutAsync(true);
        }
    }
}
