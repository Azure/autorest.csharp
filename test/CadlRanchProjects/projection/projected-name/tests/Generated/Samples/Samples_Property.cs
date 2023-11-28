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

namespace Projection.ProjectedName.Samples
{
    public partial class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Json_ShortVersion()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = client.Json(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Json_ShortVersion_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Json_ShortVersion_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = client.Json(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Json_ShortVersion_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = await client.JsonAsync(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Json_AllParameters()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = client.Json(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Json_AllParameters_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Json_AllParameters_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = client.Json(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Json_AllParameters_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonProjectedNameModel jsonProjectedNameModel = new JsonProjectedNameModel(true);
            Response response = await client.JsonAsync(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Client_ShortVersion()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = client.Client(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Client_ShortVersion_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.ClientAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Client_ShortVersion_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = client.Client(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Client_ShortVersion_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = await client.ClientAsync(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Client_AllParameters()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = client.Client(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Client_AllParameters_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.ClientAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Client_AllParameters_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = client.Client(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Client_AllParameters_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            ClientProjectedNameModel clientProjectedNameModel = new ClientProjectedNameModel(true);
            Response response = await client.ClientAsync(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Language_ShortVersion()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = client.Language(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Language_ShortVersion_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.LanguageAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Language_ShortVersion_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = client.Language(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Language_ShortVersion_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = await client.LanguageAsync(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Language_AllParameters()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = client.Language(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Language_AllParameters_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                defaultName = true,
            });
            Response response = await client.LanguageAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Language_AllParameters_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = client.Language(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Language_AllParameters_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            LanguageProjectedNameModel languageProjectedNameModel = new LanguageProjectedNameModel(true);
            Response response = await client.LanguageAsync(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_JsonAndClient_ShortVersion()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = client.JsonAndClient(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_JsonAndClient_ShortVersion_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAndClientAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_JsonAndClient_ShortVersion_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = client.JsonAndClient(jsonAndClientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_JsonAndClient_ShortVersion_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = await client.JsonAndClientAsync(jsonAndClientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_JsonAndClient_AllParameters()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = client.JsonAndClient(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_JsonAndClient_AllParameters_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                wireName = true,
            });
            Response response = await client.JsonAndClientAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_JsonAndClient_AllParameters_Convenience()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = client.JsonAndClient(jsonAndClientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_JsonAndClient_AllParameters_Convenience_Async()
        {
            Property client = new ProjectedNameClient().GetPropertyClient();

            JsonAndClientProjectedNameModel jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            Response response = await client.JsonAndClientAsync(jsonAndClientProjectedNameModel);
        }
    }
}
