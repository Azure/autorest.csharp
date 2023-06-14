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
using Projection.ProjectedName.Models;

namespace Projection.ProjectedName.Samples
{
    internal class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Json()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = client.Json(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Json_AllParameters()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = client.Json(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Json_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = await client.JsonAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Json_AllParameters_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = await client.JsonAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Json_Convenience_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var jsonProjectedNameModel = new JsonProjectedNameModel(true);
            var result = await client.JsonAsync(jsonProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Client()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = client.Client(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Client_AllParameters()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = client.Client(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Client_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = await client.ClientAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Client_AllParameters_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = await client.ClientAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Client_Convenience_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var clientProjectedNameModel = new ClientProjectedNameModel(true);
            var result = await client.ClientAsync(clientProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Language()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = client.Language(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Language_AllParameters()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = client.Language(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Language_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = await client.LanguageAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Language_AllParameters_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                defaultName = true,
            };

            Response response = await client.LanguageAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Language_Convenience_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var languageProjectedNameModel = new LanguageProjectedNameModel(true);
            var result = await client.LanguageAsync(languageProjectedNameModel);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_JsonAndClient()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = client.JsonAndClient(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_JsonAndClient_AllParameters()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = client.JsonAndClient(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_JsonAndClient_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = await client.JsonAndClientAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_JsonAndClient_AllParameters_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var data = new
            {
                wireName = true,
            };

            Response response = await client.JsonAndClientAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_JsonAndClient_Convenience_Async()
        {
            var client = new ProjectedNameClient().GetPropertyClient();

            var jsonAndClientProjectedNameModel = new JsonAndClientProjectedNameModel(true);
            var result = await client.JsonAndClientAsync(jsonAndClientProjectedNameModel);
        }
    }
}
