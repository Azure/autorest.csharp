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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public partial class Samples_Duration
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_ShortVersion()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_ShortVersion_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_ShortVersion_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_ShortVersion_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_ShortVersion()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_ShortVersion_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_ShortVersion_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_ShortVersion_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_ShortVersion()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_ShortVersion_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_ShortVersion_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_ShortVersion_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_ShortVersion()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_ShortVersion_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_ShortVersion_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_ShortVersion_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient();

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
