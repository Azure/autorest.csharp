// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Samples
{
    public partial class Samples_Duration
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetDuration_ShortVersion()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response response = client.GetDuration(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetDuration_ShortVersion_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response response = await client.GetDurationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetDuration_ShortVersion_Convenience()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response<DurationProperty> response = client.GetDuration();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetDuration_ShortVersion_Convenience_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetDurationAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetDuration_AllParameters()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response response = client.GetDuration(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetDuration_AllParameters_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response response = await client.GetDurationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_GetDuration_AllParameters_Convenience()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response<DurationProperty> response = client.GetDuration();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_GetDuration_AllParameters_Convenience_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetDurationAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_Put_ShortVersion()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_Put_ShortVersion_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_Put_ShortVersion_Convenience()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_Put_ShortVersion_Convenience_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_Put_AllParameters()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_Put_AllParameters_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Duration_Put_AllParameters_Convenience()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Duration_Put_AllParameters_Convenience_Async()
        {
            Duration client = new ValueTypesClient().GetDurationClient();

            DurationProperty body = new DurationProperty(XmlConvert.ToTimeSpan("PT1H23M45S"));
            Response response = await client.PutAsync(body);
        }
    }
}
