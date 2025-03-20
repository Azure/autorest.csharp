// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Parameters.CollectionFormat.Samples
{
    public partial class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Multi_ShortVersion()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Multi(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Multi_ShortVersion_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.MultiAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Multi_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Multi(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Multi_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.MultiAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Ssv_ShortVersion()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Ssv(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Ssv_ShortVersion_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.SsvAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Ssv_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Ssv(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Ssv_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.SsvAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Pipes_ShortVersion()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Pipes(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Pipes_ShortVersion_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.PipesAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Pipes_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Pipes(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Pipes_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.PipesAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Csv_ShortVersion()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Csv(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Csv_ShortVersion_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.CsvAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Query_Csv_AllParameters()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = client.Csv(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Query_Csv_AllParameters_Async()
        {
            Query client = new CollectionFormatClient().GetQueryClient();

            Response response = await client.CsvAsync(new string[] { "<colors>" });

            Console.WriteLine(response.Status);
        }
    }
}
