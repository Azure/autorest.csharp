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

namespace Parameters.CollectionFormat.Samples
{
    internal class Samples_Header
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv()
        {
            var client = new CollectionFormatClient().GetHeaderClient("1.0.0");

            Response response = client.Csv(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Csv_AllParameters()
        {
            var client = new CollectionFormatClient().GetHeaderClient("1.0.0");

            Response response = client.Csv(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_Async()
        {
            var client = new CollectionFormatClient().GetHeaderClient("1.0.0");

            Response response = await client.CsvAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Csv_AllParameters_Async()
        {
            var client = new CollectionFormatClient().GetHeaderClient("1.0.0");

            Response response = await client.CsvAsync(new string[] { "<colors>" });
            Console.WriteLine(response.Status);
        }
    }
}
