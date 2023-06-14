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
    public class Samples_QueriesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTrue()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanTrue();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTrue_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanTrue();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTrue_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanTrueAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTrue_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanTrueAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanFalse()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanFalse();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanFalse_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanFalse();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanFalse_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanFalseAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanFalse_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanFalseAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetBooleanNull(true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetBooleanNullAsync(true);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntOneMillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntOneMillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntOneMillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntOneMillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNegativeOneMillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntNegativeOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNegativeOneMillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntNegativeOneMillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNegativeOneMillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntNegativeOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNegativeOneMillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntNegativeOneMillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetIntNull(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetIntNullAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTenBillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTenBillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTenBillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTenBillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNegativeTenBillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetNegativeTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNegativeTenBillion_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetNegativeTenBillion();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNegativeTenBillion_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetNegativeTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNegativeTenBillion_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetNegativeTenBillionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetLongNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.GetLongNull(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetLongNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.GetLongNullAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificPositive()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatScientificPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificPositive_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatScientificPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificPositive_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatScientificPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificPositive_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatScientificPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatScientificNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatScientificNegative_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatScientificNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificNegative_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatScientificNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatScientificNegative_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatScientificNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FloatNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.FloatNull(3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FloatNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.FloatNullAsync(3.14f);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalPositive()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleDecimalPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalPositive_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleDecimalPositive();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalPositive_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleDecimalPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalPositive_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleDecimalPositiveAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleDecimalNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleDecimalNegative_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleDecimalNegative();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalNegative_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleDecimalNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleDecimalNegative_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleDecimalNegativeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DoubleNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DoubleNull(3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DoubleNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DoubleNullAsync(3.14);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUnicode()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringUnicode();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUnicode_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringUnicode();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUnicode_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringUnicodeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUnicode_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringUnicodeAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlEncoded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringUrlEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringUrlEncoded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringUrlEncoded();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlEncoded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringUrlEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringUrlEncoded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringUrlEncodedAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.StringNull("<stringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.StringNullAsync("<stringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.EnumValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.EnumValid("<enumQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.EnumValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.EnumValidAsync("<enumQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.EnumNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.EnumNull("<enumQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.EnumNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.EnumNullAsync("<enumQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteMultiByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteMultiByte();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteMultiByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteMultiByte(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteMultiByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteMultiByteAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteMultiByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteMultiByteAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ByteNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ByteNull(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ByteNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ByteNullAsync(BinaryData.FromString("<your binary data content>"));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateTimeValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateTimeValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateTimeValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateTimeValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateTimeNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DateTimeNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.DateTimeNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateTimeNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DateTimeNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.DateTimeNullAsync(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvValid(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvValidAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvNull(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvNullAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringCsvEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringCsvEmpty(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringCsvEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringCsvEmptyAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringNoCollectionFormatEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringNoCollectionFormatEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringNoCollectionFormatEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringNoCollectionFormatEmpty(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringNoCollectionFormatEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringNoCollectionFormatEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringNoCollectionFormatEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringNoCollectionFormatEmptyAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringSsvValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringSsvValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringSsvValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringSsvValid(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringSsvValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringSsvValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringSsvValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringSsvValidAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringTsvValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringTsvValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringTsvValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringTsvValid(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringTsvValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringTsvValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringTsvValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringTsvValidAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringPipesValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringPipesValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringPipesValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringPipesValid(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringPipesValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringPipesValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringPipesValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringPipesValidAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }
    }
}
