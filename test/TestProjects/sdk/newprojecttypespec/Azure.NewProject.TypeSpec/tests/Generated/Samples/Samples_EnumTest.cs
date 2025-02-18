// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.NewProject.TypeSpec.Samples
{
    public partial class Samples_EnumTest
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumTest_GetUnknownValue_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EnumTest client = new NewProjectTypeSpecClient(endpoint, credential).GetEnumTestClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.GetUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumTest_GetUnknownValue_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EnumTest client = new NewProjectTypeSpecClient(endpoint, credential).GetEnumTestClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.GetUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnumTest_GetUnknownValue_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EnumTest client = new NewProjectTypeSpecClient(endpoint, credential).GetEnumTestClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = client.GetUnknownValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnumTest_GetUnknownValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EnumTest client = new NewProjectTypeSpecClient(endpoint, credential).GetEnumTestClient();

            using RequestContent content = RequestContent.Create("Monday");
            Response response = await client.GetUnknownValueAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
