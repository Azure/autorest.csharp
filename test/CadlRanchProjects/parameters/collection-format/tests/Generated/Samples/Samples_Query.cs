// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Parameters.CollectionFormat;

namespace Parameters.CollectionFormat.Samples
{
    internal class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Multi()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Multi(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Multi_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.MultiAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Multi_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Multi(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Multi_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.MultiAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Ssv()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Ssv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Ssv_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.SsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Ssv_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Ssv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Ssv_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.SsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Tsv()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Tsv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Tsv_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.TsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Tsv_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Tsv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Tsv_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.TsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pipes()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Pipes(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pipes_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.PipesAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pipes_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Pipes(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pipes_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.PipesAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Csv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.CsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Csv(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.CsvAsync(new string[]
            {
"<colors>"
            });
            Console.WriteLine(response.Status);
        }
    }
}
