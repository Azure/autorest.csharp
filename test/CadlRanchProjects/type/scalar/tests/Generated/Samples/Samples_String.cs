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
    public partial class Samples_String
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_ShortVersion()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.GetString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_ShortVersion_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_ShortVersion_Convenience()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response<string> response = client.GetString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_ShortVersion_Convenience_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response<string> response = await client.GetStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.GetString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters_Convenience()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response<string> response = client.GetString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Convenience_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response<string> response = await client.GetStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create("<body>");
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create("<body>");
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.Put("<body>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync("<body>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create("<body>");
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create("<body>");
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = client.Put("<body>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            String client = new ScalarClient().GetStringClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync("<body>");
        }
    }
}
