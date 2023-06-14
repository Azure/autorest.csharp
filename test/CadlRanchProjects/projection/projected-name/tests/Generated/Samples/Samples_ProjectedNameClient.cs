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

namespace Projection.ProjectedName.Samples
{
    public class Samples_ProjectedNameClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var client = new ProjectedNameClient();

            Response response = client.Operation();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var client = new ProjectedNameClient();

            Response response = client.Operation();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var client = new ProjectedNameClient();

            Response response = await client.OperationAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var client = new ProjectedNameClient();

            Response response = await client.OperationAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Parameter()
        {
            var client = new ProjectedNameClient();

            Response response = client.Parameter("<defaultName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Parameter_AllParameters()
        {
            var client = new ProjectedNameClient();

            Response response = client.Parameter("<defaultName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Parameter_Async()
        {
            var client = new ProjectedNameClient();

            Response response = await client.ParameterAsync("<defaultName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Parameter_AllParameters_Async()
        {
            var client = new ProjectedNameClient();

            Response response = await client.ParameterAsync("<defaultName>");
            Console.WriteLine(response.Status);
        }
    }
}
