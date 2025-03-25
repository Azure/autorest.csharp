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
using _Specs_.Azure.Encode.Duration.Models;

namespace _Specs_.Azure.Encode.Duration.Samples
{
    public partial class Samples_DurationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_DurationConstant_ShortVersion()
        {
            DurationClient client = new DurationClient();

            using RequestContent content = RequestContent.Create(new { });
            Response response = client.DurationConstant(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_DurationConstant_ShortVersion_Async()
        {
            DurationClient client = new DurationClient();

            using RequestContent content = RequestContent.Create(new { });
            Response response = await client.DurationConstantAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_DurationConstant_ShortVersion_Convenience()
        {
            DurationClient client = new DurationClient();

            DurationModel body = new DurationModel(default);
            Response response = client.DurationConstant(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_DurationConstant_ShortVersion_Convenience_Async()
        {
            DurationClient client = new DurationClient();

            DurationModel body = new DurationModel(default);
            Response response = await client.DurationConstantAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_DurationConstant_AllParameters()
        {
            DurationClient client = new DurationClient();

            using RequestContent content = RequestContent.Create(new { });
            Response response = client.DurationConstant(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_DurationConstant_AllParameters_Async()
        {
            DurationClient client = new DurationClient();

            using RequestContent content = RequestContent.Create(new { });
            Response response = await client.DurationConstantAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_DurationConstant_AllParameters_Convenience()
        {
            DurationClient client = new DurationClient();

            DurationModel body = new DurationModel(default);
            Response response = client.DurationConstant(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_DurationConstant_AllParameters_Convenience_Async()
        {
            DurationClient client = new DurationClient();

            DurationModel body = new DurationModel(default);
            Response response = await client.DurationConstantAsync(body);
        }
    }
}
