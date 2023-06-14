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

namespace header_LowLevel.Samples
{
    public class Samples_HeaderClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamExistingKey()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamExistingKey("<userAgent>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamExistingKey_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamExistingKey("<userAgent>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamExistingKey_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamExistingKeyAsync("<userAgent>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamExistingKey_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamExistingKeyAsync("<userAgent>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseExistingKey()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseExistingKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseExistingKey_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseExistingKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseExistingKey_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseExistingKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseExistingKey_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseExistingKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamProtectedKey()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamProtectedKey("<contentType>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamProtectedKey_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamProtectedKey("<contentType>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamProtectedKey_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamProtectedKeyAsync("<contentType>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamProtectedKey_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamProtectedKeyAsync("<contentType>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseProtectedKey()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseProtectedKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseProtectedKey_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseProtectedKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseProtectedKey_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseProtectedKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseProtectedKey_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseProtectedKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamInteger()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamInteger("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamInteger_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamInteger("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamInteger_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamIntegerAsync("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamInteger_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamIntegerAsync("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseInteger()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseInteger("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseInteger_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseInteger("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseInteger_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseIntegerAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseInteger_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseIntegerAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamLong()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamLong("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamLong_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamLong("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamLong_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamLongAsync("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamLong_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamLongAsync("<scenario>", 1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseLong()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseLong("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseLong_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseLong("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseLong_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseLongAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseLong_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseLongAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamFloat()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamFloat("<scenario>", 3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamFloat_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamFloat("<scenario>", 3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamFloat_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamFloatAsync("<scenario>", 3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamFloat_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamFloatAsync("<scenario>", 3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseFloat()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseFloat("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseFloat_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseFloat("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseFloat_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseFloatAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseFloat_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseFloatAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDouble()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDouble("<scenario>", 3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDouble_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDouble("<scenario>", 3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDouble_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDoubleAsync("<scenario>", 3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDouble_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDoubleAsync("<scenario>", 3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDouble()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDouble("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDouble_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDouble("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDouble_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDoubleAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDouble_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDoubleAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamBool()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamBool("<scenario>", true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamBool_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamBool("<scenario>", true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamBool_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamBoolAsync("<scenario>", true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamBool_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamBoolAsync("<scenario>", true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseBool()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseBool("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseBool_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseBool("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseBool_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseBoolAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseBool_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseBoolAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamString("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamString("<scenario>", "<value>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamStringAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamStringAsync("<scenario>", "<value>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseString("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseString("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseStringAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseStringAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDate()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDate("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDate_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDate("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDate_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDateAsync("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDate_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDateAsync("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDate()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDate("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDate_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDate("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDate_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDateAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDate_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDateAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDatetime()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDatetime("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDatetime_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDatetime("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDatetime_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDatetimeAsync("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDatetime_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDatetimeAsync("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDatetime()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDatetime("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDatetime_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDatetime("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDatetime_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDatetimeAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDatetime_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDatetimeAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDatetimeRfc1123()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDatetimeRfc1123("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDatetimeRfc1123_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDatetimeRfc1123("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDatetimeRfc1123_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDatetimeRfc1123Async("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDatetimeRfc1123_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDatetimeRfc1123Async("<scenario>", DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDatetimeRfc1123()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDatetimeRfc1123("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDatetimeRfc1123_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDatetimeRfc1123("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDatetimeRfc1123_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDatetimeRfc1123Async("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDatetimeRfc1123_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDatetimeRfc1123Async("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDuration()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDuration("<scenario>", new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamDuration_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamDuration("<scenario>", new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDuration_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDurationAsync("<scenario>", new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamDuration_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamDurationAsync("<scenario>", new TimeSpan(1, 2, 3));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDuration()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDuration("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseDuration_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseDuration("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDuration_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDurationAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseDuration_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseDurationAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamByte("<scenario>", BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamByte("<scenario>", BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamByteAsync("<scenario>", BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamByteAsync("<scenario>", BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseByte("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseByte("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseByteAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseByteAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamEnum()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamEnum("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ParamEnum_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ParamEnum("<scenario>", "<value>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamEnum_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamEnumAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ParamEnum_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ParamEnumAsync("<scenario>", "<value>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseEnum()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseEnum("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ResponseEnum_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.ResponseEnum("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseEnum_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseEnumAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ResponseEnum_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.ResponseEnumAsync("<scenario>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomRequestId()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.CustomRequestId();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CustomRequestId_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = client.CustomRequestId();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomRequestId_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.CustomRequestIdAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CustomRequestId_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HeaderClient(credential);

            Response response = await client.CustomRequestIdAsync();
            Console.WriteLine(response.Status);
        }
    }
}
