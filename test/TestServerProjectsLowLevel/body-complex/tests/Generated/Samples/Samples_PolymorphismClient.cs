// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace body_complex_LowLevel.Samples
{
    public class Samples_PolymorphismClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "salmon",
                length = 123.45f,
            };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                location = "<location>",
                iswild = true,
                fishtype = "salmon",
                species = "<species>",
                length = 123.45f,
            };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "salmon",
                length = 123.45f,
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                location = "<location>",
                iswild = true,
                fishtype = "salmon",
                species = "<species>",
                length = 123.45f,
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDotSyntax()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetDotSyntax();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fish.type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDotSyntax_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetDotSyntax();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDotSyntax_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetDotSyntaxAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fish.type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDotSyntax_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetDotSyntaxAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComposedWithDiscriminator()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComposedWithDiscriminator();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComposedWithDiscriminator_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComposedWithDiscriminator();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComposedWithDiscriminator_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComposedWithDiscriminatorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComposedWithDiscriminator_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComposedWithDiscriminatorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComposedWithoutDiscriminator()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComposedWithoutDiscriminator();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComposedWithoutDiscriminator_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComposedWithoutDiscriminator();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComposedWithoutDiscriminator_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComposedWithoutDiscriminatorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComposedWithoutDiscriminator_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComposedWithoutDiscriminatorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleSalmon").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("salmons")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("sampleFish").GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("fish.type").ToString());
            Console.WriteLine(result.GetProperty("fishes")[0].GetProperty("species").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplicated()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComplicated();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplicated_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = client.GetComplicated();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplicated_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComplicatedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplicated_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            Response response = await client.GetComplicatedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutComplicated()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "smart_salmon",
                length = 123.45f,
            };

            Response response = client.PutComplicated(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutComplicated_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                college_degree = "<college_degree>",
                location = "<location>",
                iswild = true,
                fishtype = "smart_salmon",
                species = "<species>",
                length = 123.45f,
                siblings = new[] {
        new {
            location = "<location>",
            iswild = true,
            fishtype = "salmon",
            species = "<species>",
            length = 123.45f,
        }
    },
            };

            Response response = client.PutComplicated(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutComplicated_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "smart_salmon",
                length = 123.45f,
            };

            Response response = await client.PutComplicatedAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutComplicated_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                college_degree = "<college_degree>",
                location = "<location>",
                iswild = true,
                fishtype = "smart_salmon",
                species = "<species>",
                length = 123.45f,
                siblings = new[] {
        new {
            location = "<location>",
            iswild = true,
            fishtype = "salmon",
            species = "<species>",
            length = 123.45f,
        }
    },
            };

            Response response = await client.PutComplicatedAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutMissingDiscriminator()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "smart_salmon",
                length = 123.45f,
            };

            Response response = client.PutMissingDiscriminator(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutMissingDiscriminator_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                college_degree = "<college_degree>",
                location = "<location>",
                iswild = true,
                fishtype = "smart_salmon",
                species = "<species>",
                length = 123.45f,
                siblings = new[] {
        new {
            location = "<location>",
            iswild = true,
            fishtype = "salmon",
            species = "<species>",
            length = 123.45f,
        }
    },
            };

            Response response = client.PutMissingDiscriminator(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutMissingDiscriminator_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "smart_salmon",
                length = 123.45f,
            };

            Response response = await client.PutMissingDiscriminatorAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutMissingDiscriminator_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                college_degree = "<college_degree>",
                location = "<location>",
                iswild = true,
                fishtype = "smart_salmon",
                species = "<species>",
                length = 123.45f,
                siblings = new[] {
        new {
            location = "<location>",
            iswild = true,
            fishtype = "salmon",
            species = "<species>",
            length = 123.45f,
        }
    },
            };

            Response response = await client.PutMissingDiscriminatorAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("iswild").ToString());
            Console.WriteLine(result.GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("length").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("fishtype").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("species").ToString());
            Console.WriteLine(result.GetProperty("siblings")[0].GetProperty("length").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValidMissingRequired()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "salmon",
                length = 123.45f,
            };

            Response response = client.PutValidMissingRequired(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValidMissingRequired_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                location = "<location>",
                iswild = true,
                fishtype = "salmon",
                species = "<species>",
                length = 123.45f,
            };

            Response response = client.PutValidMissingRequired(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValidMissingRequired_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                fishtype = "salmon",
                length = 123.45f,
            };

            Response response = await client.PutValidMissingRequiredAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValidMissingRequired_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PolymorphismClient(credential);

            var data = new
            {
                location = "<location>",
                iswild = true,
                fishtype = "salmon",
                species = "<species>",
                length = 123.45f,
            };

            Response response = await client.PutValidMissingRequiredAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
