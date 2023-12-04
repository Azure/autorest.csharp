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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Tests
{
    public partial class DurationTests : _TypePropertyOptionalityTestBase
    {
        public DurationTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetAll_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutAll_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Duration_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Duration client = CreateOptionalClient(endpoint).GetDurationClient(apiVersion: "1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
