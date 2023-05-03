// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
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
        public void Example_GetBooleanFalse()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetBooleanFalse();
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
        public void Example_GetIntNegativeOneMillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetIntNegativeOneMillion();
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
        public void Example_GetNegativeTenBillion()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.GetNegativeTenBillion();
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
        public void Example_FloatScientificNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.FloatScientificNegative();
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
        public void Example_DoubleDecimalNegative()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DoubleDecimalNegative();
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
        public void Example_StringUrlEncoded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringUrlEncoded();
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
        public void Example_StringEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.StringEmpty();
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
        public void Example_EnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.EnumValid("<enumPath>");
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
        public void Example_ByteMultiByte()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteMultiByte(null);
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
        public void Example_ByteNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.ByteNull(null);
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
        public void Example_DateNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateNull(DateTimeOffset.UtcNow);
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
        public void Example_DateTimeNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.DateTimeNull(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64Url()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.Base64Url(null);
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
        public void Example_UnixTimeUrl()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathsClient(credential);

            Response response = client.UnixTimeUrl(DateTimeOffset.UtcNow);
            Console.WriteLine(response.Status);
        }
    }
}
