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

namespace Parameters.CollectionFormat.Samples
{
    internal class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Multi()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Multi(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Multi_AllParameters()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Multi(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Multi_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.MultiAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Multi_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.MultiAsync(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Ssv()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Ssv(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Ssv_AllParameters()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Ssv(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Ssv_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.SsvAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Ssv_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.SsvAsync(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Tsv()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Tsv(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Tsv_AllParameters()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Tsv(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Tsv_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.TsvAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Tsv_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.TsvAsync(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pipes()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Pipes(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pipes_AllParameters()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Pipes(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pipes_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.PipesAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pipes_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.PipesAsync(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Csv(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv_AllParameters()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = client.Csv(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.CsvAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetQueryClient("1.0.0");

            Response response = await client.CsvAsync(new string[] { "<colors>" }, new RequestContext());
            Console.WriteLine(response.Status);
        }
    }
}
