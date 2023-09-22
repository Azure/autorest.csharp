// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using ConvenienceInCadl;
using ConvenienceInCadl.Models;
using NUnit.Framework;

namespace ConvenienceInCadl.Tests
{
    public class ConvenienceInCadlClientTests : ConvenienceInCadlTestBase
    {
        public ConvenienceInCadlClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task UpdateConvenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task UpdateConvenience_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.UpdateConvenienceAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task UpdateConvenience_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task UpdateConvenience_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.UpdateConvenienceAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalBeforeRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalBeforeRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalBeforeRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(content, optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalBeforeRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(required, optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.NoConvenienceAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenience_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.NoConvenienceAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenienceRequiredBody_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceRequiredBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenienceRequiredBody_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceRequiredBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenienceOptionalBody_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = null;
            Response response = await client.NoConvenienceOptionalBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task NoConvenienceOptionalBody_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceOptionalBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Protocol_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Protocol_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithOptional_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithOptionalValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithOptional_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithOptionalValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithRequiredAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceWithRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithRequiredAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceShouldNotGenerate_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceShouldNotGenerate_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolShouldNotGenerateConvenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolShouldNotGenerateConvenience_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalQuery_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalQueryValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolOptionalQueryValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalQuery_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync(optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalQueryValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolOptionalQueryValueAsync(optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredQuery_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredQueryValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolRequiredQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredQuery_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredQueryValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolRequiredQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalModel_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = null;
            Response response = await client.ProtocolOptionalModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalModel_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalModelAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalModel_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalModel_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ProtocolOptionalModelAsync(optional: optional);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredModel_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolRequiredModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredModel_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolRequiredModelAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredModel_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolRequiredModelAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolRequiredModel_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolRequiredModelAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithOptional_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithOptionalValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithOptional_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync(optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithOptionalValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithOptionalValueAsync(optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithOptional_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithOptionalValue_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithOptional_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithOptionalValue_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithRequiredAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalQueryWithRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithRequiredAsync(optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredQueryWithRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithOptional_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = null;
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithOptional_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalModelWithOptionalAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithOptional_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithOptional_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(optional: optional);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredModelWithOptional_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredModelWithOptional_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredModelWithOptional_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceRequiredModelWithOptional_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = null;
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalModelWithRequiredAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ConvenienceOptionalModelWithRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(optional: optional);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalBeforeRequired_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalBeforeRequired_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(required);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalBeforeRequired_AllParameters_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(content, optional: 1234);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ProtocolOptionalBeforeRequired_AllParameters_Convenience_Async()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(required, optional: 1234);
        }
    }
}
