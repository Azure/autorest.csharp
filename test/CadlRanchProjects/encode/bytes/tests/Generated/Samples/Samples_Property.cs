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
using Encode.Bytes.Models;
using NUnit.Framework;

namespace Encode.Bytes.Samples
{
    public partial class Samples_Property
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_ShortVersion_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            DefaultBytesProperty body = new DefaultBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<DefaultBytesProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_ShortVersion_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            DefaultBytesProperty body = new DefaultBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<DefaultBytesProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Default(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.DefaultAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Default_AllParameters_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            DefaultBytesProperty body = new DefaultBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<DefaultBytesProperty> response = client.Default(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Default_AllParameters_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            DefaultBytesProperty body = new DefaultBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<DefaultBytesProperty> response = await client.DefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64_ShortVersion()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Base64(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64_ShortVersion_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.Base64Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64_ShortVersion_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64BytesProperty body = new Base64BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64BytesProperty> response = client.Base64(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64_ShortVersion_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64BytesProperty body = new Base64BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64BytesProperty> response = await client.Base64Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64_AllParameters()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Base64(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64_AllParameters_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.Base64Async(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64_AllParameters_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64BytesProperty body = new Base64BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64BytesProperty> response = client.Base64(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64_AllParameters_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64BytesProperty body = new Base64BytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64BytesProperty> response = await client.Base64Async(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64url_ShortVersion()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Base64url(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64url_ShortVersion_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.Base64urlAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64url_ShortVersion_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlBytesProperty body = new Base64urlBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64urlBytesProperty> response = client.Base64url(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64url_ShortVersion_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlBytesProperty body = new Base64urlBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64urlBytesProperty> response = await client.Base64urlAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64url_AllParameters()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = client.Base64url(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64url_AllParameters_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object(),
            });
            Response response = await client.Base64urlAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64url_AllParameters_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlBytesProperty body = new Base64urlBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64urlBytesProperty> response = client.Base64url(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64url_AllParameters_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlBytesProperty body = new Base64urlBytesProperty(BinaryData.FromObjectAsJson(new object()));
            Response<Base64urlBytesProperty> response = await client.Base64urlAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64urlArray_ShortVersion()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
new object()
            },
            });
            Response response = client.Base64urlArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64urlArray_ShortVersion_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
new object()
            },
            });
            Response response = await client.Base64urlArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64urlArray_ShortVersion_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlArrayBytesProperty body = new Base64urlArrayBytesProperty(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });
            Response<Base64urlArrayBytesProperty> response = client.Base64urlArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64urlArray_ShortVersion_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlArrayBytesProperty body = new Base64urlArrayBytesProperty(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });
            Response<Base64urlArrayBytesProperty> response = await client.Base64urlArrayAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64urlArray_AllParameters()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
new object()
            },
            });
            Response response = client.Base64urlArray(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64urlArray_AllParameters_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            using RequestContent content = RequestContent.Create(new
            {
                value = new object[]
            {
new object()
            },
            });
            Response response = await client.Base64urlArrayAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Property_Base64urlArray_AllParameters_Convenience()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlArrayBytesProperty body = new Base64urlArrayBytesProperty(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });
            Response<Base64urlArrayBytesProperty> response = client.Base64urlArray(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Property_Base64urlArray_AllParameters_Convenience_Async()
        {
            Property client = new BytesClient().GetPropertyClient();

            Base64urlArrayBytesProperty body = new Base64urlArrayBytesProperty(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });
            Response<Base64urlArrayBytesProperty> response = await client.Base64urlArrayAsync(body);
        }
    }
}
