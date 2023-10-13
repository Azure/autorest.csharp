// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using SpecialWords;
using SpecialWords.Models;

namespace SpecialWords.Samples
{
    public partial class SamplesModelProperties
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SameAsModel_ShortVersion()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                SameAsModel = "<SameAsModel>",
            });
            Response response = client.SameAsModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SameAsModel_ShortVersion_Async()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                SameAsModel = "<SameAsModel>",
            });
            Response response = await client.SameAsModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SameAsModel_ShortVersion_Convenience()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            SpecialWords.Models.SameAsModel body = new SpecialWords.Models.SameAsModel("<SameAsModel>");
            Response response = client.SameAsModel(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SameAsModel_ShortVersion_Convenience_Async()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            SpecialWords.Models.SameAsModel body = new SpecialWords.Models.SameAsModel("<SameAsModel>");
            Response response = await client.SameAsModelAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SameAsModel_AllParameters()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                SameAsModel = "<SameAsModel>",
            });
            Response response = client.SameAsModel(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SameAsModel_AllParameters_Async()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                SameAsModel = "<SameAsModel>",
            });
            Response response = await client.SameAsModelAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SameAsModel_AllParameters_Convenience()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            SpecialWords.Models.SameAsModel body = new SpecialWords.Models.SameAsModel("<SameAsModel>");
            Response response = client.SameAsModel(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SameAsModel_AllParameters_Convenience_Async()
        {
            ModelProperties client = new SpecialWordsClient().GetModelPropertiesClient(apiVersion: "1.0.0");

            SpecialWords.Models.SameAsModel body = new SpecialWords.Models.SameAsModel("<SameAsModel>");
            Response response = await client.SameAsModelAsync(body);
        }
    }
}
