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
    internal class Samples_Parameter
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithIf()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = client.GetWithIf("<if>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithIf_AllParameters()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = client.GetWithIf("<if>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithIf_Async()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = await client.GetWithIfAsync("<if>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithIf_AllParameters_Async()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = await client.GetWithIfAsync("<if>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithFilter()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = client.GetWithFilter("<filter>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithFilter_AllParameters()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = client.GetWithFilter("<filter>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithFilter_Async()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = await client.GetWithFilterAsync("<filter>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithFilter_AllParameters_Async()
        {
            var client = new SpecialWordsClient().GetParameterClient("1.0.0");

            Response response = await client.GetWithFilterAsync("<filter>");
            Console.WriteLine(response.Status);
        }
    }
}
