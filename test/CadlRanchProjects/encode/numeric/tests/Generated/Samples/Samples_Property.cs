// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Encode.Numeric.Models;
using NUnit.Framework;

namespace Encode.Numeric.Samples
{
    public partial class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_SafeintAsString_ShortVersion()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1234L,
            });
            Response response = client.SafeintAsString(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_SafeintAsString_ShortVersion_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1234L,
            });
            Response response = await client.SafeintAsStringAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_SafeintAsString_ShortVersion_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            SafeintAsStringProperty value = new SafeintAsStringProperty(1234L);
            Response<SafeintAsStringProperty> response = client.SafeintAsString(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_SafeintAsString_ShortVersion_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            SafeintAsStringProperty value = new SafeintAsStringProperty(1234L);
            Response<SafeintAsStringProperty> response = await client.SafeintAsStringAsync(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_SafeintAsString_AllParameters()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1234L,
            });
            Response response = client.SafeintAsString(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_SafeintAsString_AllParameters_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 1234L,
            });
            Response response = await client.SafeintAsStringAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_SafeintAsString_AllParameters_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            SafeintAsStringProperty value = new SafeintAsStringProperty(1234L);
            Response<SafeintAsStringProperty> response = client.SafeintAsString(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_SafeintAsString_AllParameters_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            SafeintAsStringProperty value = new SafeintAsStringProperty(1234L);
            Response<SafeintAsStringProperty> response = await client.SafeintAsStringAsync(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint32AsStringOptional_ShortVersion()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.Uint32AsStringOptional(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint32AsStringOptional_ShortVersion_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.Uint32AsStringOptionalAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint32AsStringOptional_ShortVersion_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint32AsStringProperty value = new Uint32AsStringProperty();
            Response<Uint32AsStringProperty> response = client.Uint32AsStringOptional(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint32AsStringOptional_ShortVersion_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint32AsStringProperty value = new Uint32AsStringProperty();
            Response<Uint32AsStringProperty> response = await client.Uint32AsStringOptionalAsync(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint32AsStringOptional_AllParameters()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Uint32AsStringOptional(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint32AsStringOptional_AllParameters_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.Uint32AsStringOptionalAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint32AsStringOptional_AllParameters_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint32AsStringProperty value = new Uint32AsStringProperty
            {
                Value = new object(),
            };
            Response<Uint32AsStringProperty> response = client.Uint32AsStringOptional(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint32AsStringOptional_AllParameters_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint32AsStringProperty value = new Uint32AsStringProperty
            {
                Value = new object(),
            };
            Response<Uint32AsStringProperty> response = await client.Uint32AsStringOptionalAsync(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint8AsString_ShortVersion()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 123,
            });
            Response response = client.Uint8AsString(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint8AsString_ShortVersion_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 123,
            });
            Response response = await client.Uint8AsStringAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint8AsString_ShortVersion_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint8AsStringProperty value = new Uint8AsStringProperty(123);
            Response<Uint8AsStringProperty> response = client.Uint8AsString(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint8AsString_ShortVersion_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint8AsStringProperty value = new Uint8AsStringProperty(123);
            Response<Uint8AsStringProperty> response = await client.Uint8AsStringAsync(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint8AsString_AllParameters()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 123,
            });
            Response response = client.Uint8AsString(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint8AsString_AllParameters_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = 123,
            });
            Response response = await client.Uint8AsStringAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Uint8AsString_AllParameters_Convenience()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint8AsStringProperty value = new Uint8AsStringProperty(123);
            Response<Uint8AsStringProperty> response = client.Uint8AsString(value);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Uint8AsString_AllParameters_Convenience_Async()
        {
            Property client = new NumericClient().GetPropertyClient();

            Uint8AsStringProperty value = new Uint8AsStringProperty(123);
            Response<Uint8AsStringProperty> response = await client.Uint8AsStringAsync(value);
        }
    }
}
