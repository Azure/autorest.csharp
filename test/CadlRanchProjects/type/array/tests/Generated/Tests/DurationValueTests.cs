// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type._Array;

namespace _Type._Array.Tests
{
    public class DurationValueTests : _Type_ArrayTestBase
    {
        public DurationValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDurationValue_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response response = await client.GetDurationValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDurationValue_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<TimeSpan>> response = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDurationValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response response = await client.GetDurationValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDurationValue_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<TimeSpan>> response = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"PT1H23M45S"
});
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<TimeSpan>()
{
XmlConvert.ToTimeSpan("PT1H23M45S")
});
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
"PT1H23M45S"
});
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            DurationValue client = CreateArrayClient(endpoint).GetDurationValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<TimeSpan>()
{
XmlConvert.ToTimeSpan("PT1H23M45S")
});
        }
    }
}
