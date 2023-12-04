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
    public partial class ConvenienceInCadlClientTests : ConvenienceInCadlTestBase
    {
        public ConvenienceInCadlClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_UpdateConvenience_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_UpdateConvenience_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.UpdateConvenienceAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_UpdateConvenience_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.UpdateConvenienceAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_UpdateConvenience_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.UpdateConvenienceAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalBeforeRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalBeforeRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalBeforeRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(content, optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalBeforeRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceOptionalBeforeRequiredAsync(required, optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenience_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.NoConvenienceAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenience_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.NoConvenienceAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenienceRequiredBody_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceRequiredBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenienceRequiredBody_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceRequiredBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenienceOptionalBody_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = null;
            Response response = await client.NoConvenienceOptionalBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_NoConvenienceOptionalBody_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.NoConvenienceOptionalBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_Protocol_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_Protocol_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_Protocol_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_Protocol_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithOptional_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithOptional_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithOptional_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithOptionalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithOptional_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithRequiredAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceWithRequiredAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceWithRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceWithRequiredAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceShouldNotGenerate_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceShouldNotGenerate_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceShouldNotGenerateAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolShouldNotGenerateConvenience_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolShouldNotGenerateConvenience_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolShouldNotGenerateConvenienceAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalQuery_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalQuery_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolOptionalQueryValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalQuery_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalQueryAsync(optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalQuery_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolOptionalQueryValueAsync(optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredQuery_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredQuery_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolRequiredQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredQuery_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolRequiredQueryAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredQuery_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ProtocolRequiredQueryValueAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalModel_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = null;
            Response response = await client.ProtocolOptionalModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalModel_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ProtocolOptionalModelAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalModel_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalModel_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ProtocolOptionalModelAsync(optional: optional);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredModel_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolRequiredModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredModel_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolRequiredModelAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredModel_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolRequiredModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolRequiredModel_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolRequiredModelAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithOptional_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithOptional_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithOptionalValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithOptional_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithOptionalAsync(optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithOptional_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithOptionalValueAsync(optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithOptional_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithOptional_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithOptional_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithOptionalAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithOptional_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithOptionalValueAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(null, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithRequiredAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalQueryWithRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceOptionalQueryWithRequiredAsync(optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredQueryWithRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response<Model> response = await client.ConvenienceRequiredQueryWithRequiredAsync(1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithOptional_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = null;
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithOptional_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalModelWithOptionalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithOptional_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithOptional_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ConvenienceOptionalModelWithOptionalAsync(optional: optional);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredModelWithOptional_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredModelWithOptional_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredModelWithOptional_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceRequiredModelWithOptional_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ConvenienceRequiredModelWithOptionalAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = null;
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Response response = await client.ConvenienceOptionalModelWithRequiredAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ConvenienceOptionalModelWithRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model optional = new Model("<id>");
            Response response = await client.ConvenienceOptionalModelWithRequiredAsync(optional: optional);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalBeforeRequired_ShortVersion()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalBeforeRequired_ShortVersion_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(required);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalBeforeRequired_AllParameters()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(content, optional: 1234);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ConvenienceInCadl_ProtocolOptionalBeforeRequired_AllParameters_Convenience()
        {
            ConvenienceInCadlClient client = CreateConvenienceInCadlClient();

            Model required = new Model("<id>");
            Response response = await client.ProtocolOptionalBeforeRequiredAsync(required, optional: 1234);
        }
    }
}
