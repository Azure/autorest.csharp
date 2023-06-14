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

namespace body_complex_LowLevel.Samples
{
    public class Samples_PrimitiveClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInt()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetInt();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInt_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetInt();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInt_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetIntAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInt_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetIntAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutInt()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutInt(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutInt_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 1234,
                field2 = 1234,
            };

            Response response = client.PutInt(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutInt_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutIntAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutInt_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 1234,
                field2 = 1234,
            };

            Response response = await client.PutIntAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLong()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetLong();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLong_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetLong();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLong_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetLongAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLong_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetLongAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutLong()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutLong(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutLong_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 1234L,
                field2 = 1234L,
            };

            Response response = client.PutLong(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutLong_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutLongAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutLong_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 1234L,
                field2 = 1234L,
            };

            Response response = await client.PutLongAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetFloat();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetFloat();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetFloatAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetFloatAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field2").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFloat()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutFloat(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFloat_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 123.45f,
                field2 = 123.45f,
            };

            Response response = client.PutFloat(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFloat_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutFloatAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFloat_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 123.45f,
                field2 = 123.45f,
            };

            Response response = await client.PutFloatAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDouble()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDouble();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDouble_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDouble();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDouble_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDoubleAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDouble_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDoubleAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field1").ToString());
            Console.WriteLine(result.GetProperty("field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDouble()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutDouble(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDouble_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 123.45d,
                field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose = 123.45d,
            };

            Response response = client.PutDouble(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDouble_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutDoubleAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDouble_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field1 = 123.45d,
                field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose = 123.45d,
            };

            Response response = await client.PutDoubleAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBool()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetBool();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBool_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetBool();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field_true").ToString());
            Console.WriteLine(result.GetProperty("field_false").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBool_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetBoolAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBool_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetBoolAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field_true").ToString());
            Console.WriteLine(result.GetProperty("field_false").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutBool()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutBool(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutBool_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field_true = true,
                field_false = true,
            };

            Response response = client.PutBool(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutBool_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutBoolAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutBool_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field_true = true,
                field_false = true,
            };

            Response response = await client.PutBoolAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("empty").ToString());
            Console.WriteLine(result.GetProperty("null").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("empty").ToString());
            Console.WriteLine(result.GetProperty("null").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutString(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "<field>",
                empty = "<empty>",
                @null = "<null>",
            };

            Response response = client.PutString(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutStringAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "<field>",
                empty = "<empty>",
                @null = "<null>",
            };

            Response response = await client.PutStringAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDate()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDate();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDate_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDate();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("leap").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDate_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDate_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("leap").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDate()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutDate(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDate_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "2022-05-10",
                leap = "2022-05-10",
            };

            Response response = client.PutDate(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDate_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutDateAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDate_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "2022-05-10",
                leap = "2022-05-10",
            };

            Response response = await client.PutDateAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTime()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDateTime();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTime_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDateTime();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("now").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTime_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateTimeAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTime_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateTimeAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("now").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTime()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutDateTime(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTime_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "2022-05-10T18:57:31.2311892Z",
                now = "2022-05-10T18:57:31.2311892Z",
            };

            Response response = client.PutDateTime(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTime_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutDateTimeAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTime_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "2022-05-10T18:57:31.2311892Z",
                now = "2022-05-10T18:57:31.2311892Z",
            };

            Response response = await client.PutDateTimeAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeRfc1123()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDateTimeRfc1123();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeRfc1123_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDateTimeRfc1123();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("now").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeRfc1123_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateTimeRfc1123Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeRfc1123_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDateTimeRfc1123Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
            Console.WriteLine(result.GetProperty("now").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeRfc1123()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutDateTimeRfc1123(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeRfc1123_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "Tue, 10 May 2022 18:57:31 GMT",
                now = "Tue, 10 May 2022 18:57:31 GMT",
            };

            Response response = client.PutDateTimeRfc1123(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeRfc1123_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutDateTimeRfc1123Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeRfc1123_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "Tue, 10 May 2022 18:57:31 GMT",
                now = "Tue, 10 May 2022 18:57:31 GMT",
            };

            Response response = await client.PutDateTimeRfc1123Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDuration()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDuration();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDuration_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetDuration();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDuration_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDurationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDuration_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetDurationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDuration()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutDuration(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDuration_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "PT1H23M45S",
            };

            Response response = client.PutDuration(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDuration_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutDurationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDuration_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = "PT1H23M45S",
            };

            Response response = await client.PutDurationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetByte();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = client.GetByte();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetByteAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            Response response = await client.GetByteAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("field").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = client.PutByte(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutByte_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = new { },
            };

            Response response = client.PutByte(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutByte_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new { };

            Response response = await client.PutByteAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutByte_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PrimitiveClient(credential);

            var data = new
            {
                field = new { },
            };

            Response response = await client.PutByteAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
