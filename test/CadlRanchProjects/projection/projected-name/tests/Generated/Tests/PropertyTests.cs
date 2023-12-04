// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Projection.ProjectedName;
using Projection.ProjectedName.Models;

namespace Projection.ProjectedName.Tests
{
    public partial class PropertyTests : ProjectionProjectedNameTestBase
    {
        public PropertyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Json_ShortVersion()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Json_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = await client.JsonAsync(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Json_AllParameters()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Json_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = await client.JsonAsync(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Client_ShortVersion()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.ClientAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Client_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = await client.ClientAsync(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Client_AllParameters()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.ClientAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Client_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = await client.ClientAsync(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Language_ShortVersion()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.LanguageAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Language_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = await client.LanguageAsync(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Language_AllParameters()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.LanguageAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_Language_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = await client.LanguageAsync(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_JsonAndClient_ShortVersion()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAndClientAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_JsonAndClient_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = await client.JsonAndClientAsync(jsonAndClientProjectedNameModel);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_JsonAndClient_AllParameters()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAndClientAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Property_JsonAndClient_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Property client = CreateProjectedNameClient(endpoint).GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = await client.JsonAndClientAsync(jsonAndClientProjectedNameModel);
        }
    }
}
