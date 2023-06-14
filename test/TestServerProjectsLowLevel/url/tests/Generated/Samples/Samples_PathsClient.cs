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

namespace url_LowLevel.Samples
{
    public class Samples_PathsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTrue()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetBooleanTrue();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTrue_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetBooleanTrue();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTrue_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetBooleanTrueAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTrue_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetBooleanTrueAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanFalse()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetBooleanFalse();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanFalse_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetBooleanFalse();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanFalse_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetBooleanFalseAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanFalse_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetBooleanFalseAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntOneMillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetIntOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntOneMillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetIntOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntOneMillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetIntOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntOneMillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetIntOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNegativeOneMillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetIntNegativeOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNegativeOneMillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetIntNegativeOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNegativeOneMillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetIntNegativeOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNegativeOneMillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetIntNegativeOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTenBillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTenBillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTenBillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTenBillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNegativeTenBillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetNegativeTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNegativeTenBillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetNegativeTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNegativeTenBillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetNegativeTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNegativeTenBillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.GetNegativeTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificPositive()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.FloatScientificPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificPositive_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.FloatScientificPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificPositive_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.FloatScientificPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificPositive_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.FloatScientificPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.FloatScientificNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificNegative_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.FloatScientificNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificNegative_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.FloatScientificNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificNegative_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.FloatScientificNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalPositive()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DoubleDecimalPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalPositive_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DoubleDecimalPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalPositive_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DoubleDecimalPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalPositive_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DoubleDecimalPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DoubleDecimalNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalNegative_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DoubleDecimalNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalNegative_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DoubleDecimalNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalNegative_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DoubleDecimalNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUnicode()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUnicode();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUnicode_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUnicode();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUnicode_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUnicodeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUnicode_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUnicodeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlEncoded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUrlEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlEncoded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUrlEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlEncoded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUrlEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlEncoded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUrlEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlNonEncoded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUrlNonEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlNonEncoded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUrlNonEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlNonEncoded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUrlNonEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlNonEncoded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringUrlNonEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringNull("<stringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringNull("<stringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringNullAsync("<stringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.StringNullAsync("<stringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.EnumValid("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.EnumValid("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.EnumValidAsync("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.EnumValidAsync("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.EnumNull("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.EnumNull("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.EnumNullAsync("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.EnumNullAsync("<enumPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteMultiByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteMultiByte(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteMultiByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteMultiByte(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteMultiByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteMultiByteAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteMultiByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteMultiByteAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteNull(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteNull(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteNullAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ByteNullAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateTimeValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateTimeValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateTimeValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateTimeValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateTimeNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateTimeNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateTimeNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.DateTimeNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64Url()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.Base64Url(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64Url_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.Base64Url(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64Url_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.Base64UrlAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64Url_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.Base64UrlAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayCsvInPath()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ArrayCsvInPath(new string[] { "<arrayPath>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayCsvInPath_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ArrayCsvInPath(new string[] { "<arrayPath>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayCsvInPath_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ArrayCsvInPathAsync(new string[] { "<arrayPath>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayCsvInPath_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.ArrayCsvInPathAsync(new string[] { "<arrayPath>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimeUrl()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.UnixTimeUrl(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UnixTimeUrl_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.UnixTimeUrl(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimeUrl_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.UnixTimeUrlAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UnixTimeUrl_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = await client.UnixTimeUrlAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }
    }
}
