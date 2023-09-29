// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using media_types_LowLevel;

namespace media_types_LowLevel.Samples
{
    public partial class Samples_MediaTypesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnalyzeBody_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = client.AnalyzeBody(content, new ContentType("application/pdf"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnalyzeBody_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = await client.AnalyzeBodyAsync(content, new ContentType("application/pdf"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnalyzeBody_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.AnalyzeBody(content, new ContentType("application/pdf"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnalyzeBody_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.AnalyzeBodyAsync(content, new ContentType("application/pdf"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnalyzeBodyNoAcceptHeader_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = client.AnalyzeBodyNoAcceptHeader(content, new ContentType("application/pdf"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnalyzeBodyNoAcceptHeader_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = await client.AnalyzeBodyNoAcceptHeaderAsync(content, new ContentType("application/pdf"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AnalyzeBodyNoAcceptHeader_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.AnalyzeBodyNoAcceptHeader(content, new ContentType("application/pdf"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AnalyzeBodyNoAcceptHeader_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.AnalyzeBodyNoAcceptHeaderAsync(content, new ContentType("application/pdf"));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ContentTypeWithEncoding_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = client.ContentTypeWithEncoding(content);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ContentTypeWithEncoding_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = null;
            Response response = await client.ContentTypeWithEncodingAsync(content);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ContentTypeWithEncoding_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<input>");
            Response response = client.ContentTypeWithEncoding(content);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ContentTypeWithEncoding_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<input>");
            Response response = await client.ContentTypeWithEncodingAsync(content);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BinaryBodyWithTwoContentTypes_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BinaryBodyWithTwoContentTypes(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BinaryBodyWithTwoContentTypes_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BinaryBodyWithTwoContentTypesAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BinaryBodyWithTwoContentTypes_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BinaryBodyWithTwoContentTypes(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BinaryBodyWithTwoContentTypes_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BinaryBodyWithTwoContentTypesAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BinaryBodyWithThreeContentTypes_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BinaryBodyWithThreeContentTypes(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BinaryBodyWithThreeContentTypes_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BinaryBodyWithThreeContentTypesAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BinaryBodyWithThreeContentTypes_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BinaryBodyWithThreeContentTypes(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BinaryBodyWithThreeContentTypes_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BinaryBodyWithThreeContentTypesAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BodyThreeTypes_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BodyThreeTypes(content, new ContentType("application/octet-stream"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BodyThreeTypes_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BodyThreeTypesAsync(content, new ContentType("application/octet-stream"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_BodyThreeTypes_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = client.BodyThreeTypes(content, new ContentType("application/octet-stream"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_BodyThreeTypes_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.BodyThreeTypesAsync(content, new ContentType("application/octet-stream"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutTextAndJsonBody_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<message>");
            Response response = client.PutTextAndJsonBody(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutTextAndJsonBody_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<message>");
            Response response = await client.PutTextAndJsonBodyAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutTextAndJsonBody_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<message>");
            Response response = client.PutTextAndJsonBody(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutTextAndJsonBody_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MediaTypesClient client = new MediaTypesClient(credential);

            RequestContent content = RequestContent.Create("<message>");
            Response response = await client.PutTextAndJsonBodyAsync(content, new ContentType("application/json"));

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }
    }
}
