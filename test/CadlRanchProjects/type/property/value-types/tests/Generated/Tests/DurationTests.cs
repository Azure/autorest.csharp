// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Tests
{
    public partial class DurationTests : _TypePropertyValueTypesTestBase
    {
        public DurationTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDuration_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            Response response = await client.GetDurationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDuration_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            Response<DurationProperty> response = await client.GetDurationAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDuration_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            Response response = await client.GetDurationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDuration_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            Response<DurationProperty> response = await client.GetDurationAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_Put_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_Put_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateValueTypesClient(endpoint).GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = await client.PutAsync(body);
        }
    }
}
