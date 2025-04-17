// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace FirstTestTypeSpec.Samples
{
    public partial class Samples_VersioningOp
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_VersioningOp_Export_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = client.Export(WaitUntil.Completed, "<name>", null, null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_VersioningOp_Export_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = await client.ExportAsync(WaitUntil.Completed, "<name>", null, null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_VersioningOp_Export_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = client.Export(WaitUntil.Completed, "<name>", "<projectFileVersion>", null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_VersioningOp_Export_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = await client.ExportAsync(WaitUntil.Completed, "<name>", "<projectFileVersion>", null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_VersioningOp_ExportW_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = client.ExportW(WaitUntil.Completed, "<name>", null, null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_VersioningOp_ExportW_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = await client.ExportWAsync(WaitUntil.Completed, "<name>", null, null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_VersioningOp_ExportW_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = client.ExportW(WaitUntil.Completed, "<name>", "<projectFileVersion>", null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_VersioningOp_ExportW_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            VersioningOp client = new FirstTestTypeSpecClient(endpoint).GetVersioningOpClient();

            Operation<BinaryData> operation = await client.ExportWAsync(WaitUntil.Completed, "<name>", "<projectFileVersion>", null);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }
    }
}
