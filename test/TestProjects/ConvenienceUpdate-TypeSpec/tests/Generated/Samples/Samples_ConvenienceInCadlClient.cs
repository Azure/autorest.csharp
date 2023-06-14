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
using ConvenienceInCadl.Models;
using NUnit.Framework;

namespace ConvenienceInCadl.Samples
{
    public class Samples_ConvenienceInCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateConvenience()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.UpdateConvenience(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateConvenience_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.UpdateConvenience(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateConvenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateConvenience_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateConvenience_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.UpdateConvenienceAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalBeforeRequired()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalBeforeRequired(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalBeforeRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalBeforeRequired(RequestContent.Create(data), 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalBeforeRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalBeforeRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(RequestContent.Create(data), 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalBeforeRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var required = new Model("<id>");
            var result = await client.ConvenienceOptionalBeforeRequiredAsync(required, 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Protocol()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.Protocol();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Protocol_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.Protocol();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Protocol_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Protocol_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ProtocolValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceWithOptional()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceWithOptional();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceWithOptional_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceWithOptional();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithOptional_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithOptional_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithOptionalValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceWithRequired()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceWithRequired(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceWithRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceWithRequired(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceWithRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceWithRequiredAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceShouldNotGenerate()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceShouldNotGenerate();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceShouldNotGenerate_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceShouldNotGenerate();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceShouldNotGenerate_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceShouldNotGenerate_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolShouldNotGenerateConvenience()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolShouldNotGenerateConvenience();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolShouldNotGenerateConvenience_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolShouldNotGenerateConvenience();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolShouldNotGenerateConvenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolShouldNotGenerateConvenience_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalQuery()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolOptionalQuery();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalQuery_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolOptionalQuery(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalQuery_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalQuery_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalQueryValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ProtocolOptionalQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolRequiredQuery()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolRequiredQuery(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolRequiredQuery_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ProtocolRequiredQuery(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredQuery_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredQuery_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredQueryValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ProtocolRequiredQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalModel()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolOptionalModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalModel_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolOptionalModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalModel_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolOptionalModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalModel_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolOptionalModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalModelValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var optional = new Model("<id>");
            var result = await client.ProtocolOptionalModelValueAsync(optional);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolRequiredModel()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolRequiredModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolRequiredModel_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolRequiredModel(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredModel_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolRequiredModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredModel_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolRequiredModelAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolRequiredModel_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var required = new Model("<id>");
            var result = await client.ProtocolRequiredModelAsync(required);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalQueryWithOptional()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceOptionalQueryWithOptional();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalQueryWithOptional_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceOptionalQueryWithOptional(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithOptional_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithOptional_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithOptionalValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceOptionalQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredQueryWithOptional()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceRequiredQueryWithOptional(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredQueryWithOptional_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceRequiredQueryWithOptional(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithOptional_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithOptional_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithOptionalValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceRequiredQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalQueryWithRequired()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceOptionalQueryWithRequired(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalQueryWithRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceOptionalQueryWithRequired(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalQueryWithRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceOptionalQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredQueryWithRequired()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceRequiredQueryWithRequired(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredQueryWithRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            Response response = client.ConvenienceRequiredQueryWithRequired(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredQueryWithRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var result = await client.ConvenienceRequiredQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalModelWithOptional()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalModelWithOptional(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalModelWithOptional_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalModelWithOptional(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithOptional_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithOptional_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithOptionalValue_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var optional = new Model("<id>");
            var result = await client.ConvenienceOptionalModelWithOptionalValueAsync(optional);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredModelWithOptional()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceRequiredModelWithOptional(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceRequiredModelWithOptional_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceRequiredModelWithOptional(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredModelWithOptional_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredModelWithOptional_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceRequiredModelWithOptional_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var required = new Model("<id>");
            var result = await client.ConvenienceRequiredModelWithOptionalAsync(required);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalModelWithRequired()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalModelWithRequired(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ConvenienceOptionalModelWithRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ConvenienceOptionalModelWithRequired(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ConvenienceOptionalModelWithRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var optional = new Model("<id>");
            var result = await client.ConvenienceOptionalModelWithRequiredAsync(optional);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalBeforeRequired()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolOptionalBeforeRequired(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ProtocolOptionalBeforeRequired_AllParameters()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = client.ProtocolOptionalBeforeRequired(RequestContent.Create(data), 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalBeforeRequired_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolOptionalBeforeRequiredAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalBeforeRequired_AllParameters_Async()
        {
            var client = new ConvenienceInCadlClient();

            var data = new
            {
                id = "<id>",
            };

            Response response = await client.ProtocolOptionalBeforeRequiredAsync(RequestContent.Create(data), 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ProtocolOptionalBeforeRequired_Convenience_Async()
        {
            var client = new ConvenienceInCadlClient();

            var required = new Model("<id>");
            var result = await client.ProtocolOptionalBeforeRequiredAsync(required, 1234);
        }
    }
}
