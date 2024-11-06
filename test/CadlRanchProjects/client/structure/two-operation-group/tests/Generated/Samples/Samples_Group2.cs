// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Client.Structure.Service.TwoOperationGroup.Models;
using NUnit.Framework;

namespace Client.Structure.Service.TwoOperationGroup.Samples
{
    public partial class Samples_Group2
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Two_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Two();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Two_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.TwoAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Two_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Two();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Two_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.TwoAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Five_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Five();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Five_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.FiveAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Five_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Five();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Five_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.FiveAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Six_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Six();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Six_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.SixAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group2_Six_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = client.Six();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group2_Six_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group2 client = new TwoOperationGroupClient(endpoint, default).GetGroup2Client();

            Response response = await client.SixAsync();

            Console.WriteLine(response.Status);
        }
    }
}
