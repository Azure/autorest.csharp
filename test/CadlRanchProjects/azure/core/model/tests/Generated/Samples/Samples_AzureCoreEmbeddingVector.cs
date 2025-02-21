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
using _Specs_.Azure.Core.Model.Models;

namespace _Specs_.Azure.Core.Model.Samples
{
    public partial class Samples_AzureCoreEmbeddingVector
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_ShortVersion()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = client.GetAzureCoreEmbeddingVector(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_ShortVersion_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = await client.GetAzureCoreEmbeddingVectorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_ShortVersion_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response<ReadOnlyMemory<int>> response = client.GetAzureCoreEmbeddingVector();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_ShortVersion_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response<ReadOnlyMemory<int>> response = await client.GetAzureCoreEmbeddingVectorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_AllParameters()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = client.GetAzureCoreEmbeddingVector(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_AllParameters_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = await client.GetAzureCoreEmbeddingVectorAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_AllParameters_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response<ReadOnlyMemory<int>> response = client.GetAzureCoreEmbeddingVector();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_GetAzureCoreEmbeddingVector_AllParameters_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response<ReadOnlyMemory<int>> response = await client.GetAzureCoreEmbeddingVectorAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Put_ShortVersion()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Put_ShortVersion_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Put_ShortVersion_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = client.Put(new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Put_ShortVersion_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = await client.PutAsync(new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Put_AllParameters()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Put_AllParameters_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Put_AllParameters_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = client.Put(new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Put_AllParameters_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            Response response = await client.PutAsync(new int[] { 1234 });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Post_ShortVersion()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new
            {
                embedding = new object[]
            {
1234
            },
            });
            Response response = client.Post(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("embedding")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Post_ShortVersion_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new
            {
                embedding = new object[]
            {
1234
            },
            });
            Response response = await client.PostAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("embedding")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Post_ShortVersion_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            AzureEmbeddingModel body = new AzureEmbeddingModel(new int[] { 1234 });
            Response<AzureEmbeddingModel> response = client.Post(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Post_ShortVersion_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            AzureEmbeddingModel body = new AzureEmbeddingModel(new int[] { 1234 });
            Response<AzureEmbeddingModel> response = await client.PostAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Post_AllParameters()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new
            {
                embedding = new object[]
            {
1234
            },
            });
            Response response = client.Post(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("embedding")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Post_AllParameters_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            using RequestContent content = RequestContent.Create(new
            {
                embedding = new object[]
            {
1234
            },
            });
            Response response = await client.PostAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("embedding")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureCoreEmbeddingVector_Post_AllParameters_Convenience()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            AzureEmbeddingModel body = new AzureEmbeddingModel(new int[] { 1234 });
            Response<AzureEmbeddingModel> response = client.Post(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureCoreEmbeddingVector_Post_AllParameters_Convenience_Async()
        {
            AzureCoreEmbeddingVector client = new ModelClient().GetAzureCoreEmbeddingVectorClient();

            AzureEmbeddingModel body = new AzureEmbeddingModel(new int[] { 1234 });
            Response<AzureEmbeddingModel> response = await client.PostAsync(body);
        }
    }
}
