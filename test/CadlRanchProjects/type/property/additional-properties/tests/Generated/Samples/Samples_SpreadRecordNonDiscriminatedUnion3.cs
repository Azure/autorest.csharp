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
using _Type.Property.AdditionalProperties.Models;

namespace _Type.Property.AdditionalProperties.Samples
{
    public partial class Samples_SpreadRecordNonDiscriminatedUnion3
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_ShortVersion()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response response = client.GetSpreadRecordNonDiscriminatedUnion3(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_ShortVersion_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response response = await client.GetSpreadRecordNonDiscriminatedUnion3Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_ShortVersion_Convenience()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response<SpreadRecordForNonDiscriminatedUnion3> response = client.GetSpreadRecordNonDiscriminatedUnion3();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_ShortVersion_Convenience_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response<SpreadRecordForNonDiscriminatedUnion3> response = await client.GetSpreadRecordNonDiscriminatedUnion3Async();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_AllParameters()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response response = client.GetSpreadRecordNonDiscriminatedUnion3(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_AllParameters_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response response = await client.GetSpreadRecordNonDiscriminatedUnion3Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_AllParameters_Convenience()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response<SpreadRecordForNonDiscriminatedUnion3> response = client.GetSpreadRecordNonDiscriminatedUnion3();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_GetSpreadRecordNonDiscriminatedUnion3_AllParameters_Convenience_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            Response<SpreadRecordForNonDiscriminatedUnion3> response = await client.GetSpreadRecordNonDiscriminatedUnion3Async();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_Put_ShortVersion()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_Put_ShortVersion_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_Put_ShortVersion_Convenience()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            SpreadRecordForNonDiscriminatedUnion3 body = new SpreadRecordForNonDiscriminatedUnion3("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_Put_ShortVersion_Convenience_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            SpreadRecordForNonDiscriminatedUnion3 body = new SpreadRecordForNonDiscriminatedUnion3("<name>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_Put_AllParameters()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_Put_AllParameters_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SpreadRecordNonDiscriminatedUnion3_Put_AllParameters_Convenience()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            SpreadRecordForNonDiscriminatedUnion3 body = new SpreadRecordForNonDiscriminatedUnion3("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SpreadRecordNonDiscriminatedUnion3_Put_AllParameters_Convenience_Async()
        {
            SpreadRecordNonDiscriminatedUnion3 client = new AdditionalPropertiesClient().GetSpreadRecordNonDiscriminatedUnion3Client();

            SpreadRecordForNonDiscriminatedUnion3 body = new SpreadRecordForNonDiscriminatedUnion3("<name>");
            Response response = await client.PutAsync(body);
        }
    }
}
