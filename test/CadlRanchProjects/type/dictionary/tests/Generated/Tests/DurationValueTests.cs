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

namespace _Type._Dictionary.Tests
{
    public partial class DurationValueTests : _Type_DictionaryTestBase
    {
        public DurationValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_GetDurationValue_ShortVersion()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response response = await client.GetDurationValueAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_GetDurationValue_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response<IReadOnlyDictionary<string, TimeSpan>> response = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_GetDurationValue_AllParameters()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response response = await client.GetDurationValueAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_GetDurationValue_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response<IReadOnlyDictionary<string, TimeSpan>> response = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_Put_ShortVersion()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response response = await client.PutAsync(new Dictionary<string, TimeSpan>
            {
                ["key"] = XmlConvert.ToTimeSpan("PT1H23M45S")
            });
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_Put_AllParameters()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DurationValue_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DurationValue client = CreateDictionaryClient(endpoint).GetDurationValueClient();

            Response response = await client.PutAsync(new Dictionary<string, TimeSpan>
            {
                ["key"] = XmlConvert.ToTimeSpan("PT1H23M45S")
            });
        }
    }
}
