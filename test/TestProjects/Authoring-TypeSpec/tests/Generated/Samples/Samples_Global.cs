// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace AuthoringTypeSpec.Samples
{
    public partial class Samples_Global
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Global_GetSupportedLanguages_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            foreach (BinaryData item in client.GetSupportedLanguages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Global_GetSupportedLanguages_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetSupportedLanguagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Global_GetSupportedLanguages_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            foreach (BinaryData item in client.GetSupportedLanguages(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Global_GetSupportedLanguages_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetSupportedLanguagesAsync(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Global_GetTrainingConfigVersions_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            foreach (BinaryData item in client.GetTrainingConfigVersions())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Global_GetTrainingConfigVersions_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetTrainingConfigVersionsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Global_GetTrainingConfigVersions_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            foreach (BinaryData item in client.GetTrainingConfigVersions(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Global_GetTrainingConfigVersions_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Global client = new AuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetTrainingConfigVersionsAsync(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }
    }
}
