// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Parameters.QueryOptionality.Samples
{
    public partial class Samples_QueryOptionalityClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_QueryOptionality_FromRequired_ShortVersion()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = client.FromRequired("<start>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_QueryOptionality_FromRequired_ShortVersion_Async()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = await client.FromRequiredAsync("<start>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_QueryOptionality_FromRequired_AllParameters()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = client.FromRequired("<start>", end: "<end>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_QueryOptionality_FromRequired_AllParameters_Async()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = await client.FromRequiredAsync("<start>", end: "<end>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_QueryOptionality_FromOptional_ShortVersion()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = client.FromOptional("<end>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_QueryOptionality_FromOptional_ShortVersion_Async()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = await client.FromOptionalAsync("<end>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_QueryOptionality_FromOptional_AllParameters()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = client.FromOptional("<end>", start: "<start>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_QueryOptionality_FromOptional_AllParameters_Async()
        {
            QueryOptionalityClient client = new QueryOptionalityClient();

            Response response = await client.FromOptionalAsync("<end>", start: "<start>");

            Console.WriteLine(response.Status);
        }
    }
}
