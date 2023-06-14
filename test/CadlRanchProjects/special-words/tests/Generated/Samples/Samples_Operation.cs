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

namespace SpecialWords.Samples
{
    internal class Samples_Operation
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_For()
        {
            var client = new SpecialWordsClient().GetOperationClient("1.0.0");

            Response response = client.For();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_For_AllParameters()
        {
            var client = new SpecialWordsClient().GetOperationClient("1.0.0");

            Response response = client.For();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_For_Async()
        {
            var client = new SpecialWordsClient().GetOperationClient("1.0.0");

            Response response = await client.ForAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_For_AllParameters_Async()
        {
            var client = new SpecialWordsClient().GetOperationClient("1.0.0");

            Response response = await client.ForAsync();
            Console.WriteLine(response.Status);
        }
    }
}
