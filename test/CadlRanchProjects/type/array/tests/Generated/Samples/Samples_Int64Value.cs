// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace _Type._Array.Samples
{
    public partial class Samples_Int64Value
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_GetInt64Value_ShortVersion()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = client.GetInt64Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_GetInt64Value_ShortVersion_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = await client.GetInt64ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_GetInt64Value_ShortVersion_Convenience()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = client.GetInt64Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_GetInt64Value_ShortVersion_Convenience_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = await client.GetInt64ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_GetInt64Value_AllParameters()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = client.GetInt64Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_GetInt64Value_AllParameters_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = await client.GetInt64ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_GetInt64Value_AllParameters_Convenience()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = client.GetInt64Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_GetInt64Value_AllParameters_Convenience_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response<IReadOnlyList<long>> response = await client.GetInt64ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_Put_ShortVersion()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_Put_ShortVersion_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_Put_ShortVersion_Convenience()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = client.Put(new long[] { 1234L });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_Put_ShortVersion_Convenience_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = await client.PutAsync(new long[] { 1234L });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_Put_AllParameters()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_Put_AllParameters_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            using RequestContent content = RequestContent.Create(new object[]
            {
1234L
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Int64Value_Put_AllParameters_Convenience()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = client.Put(new long[] { 1234L });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Int64Value_Put_AllParameters_Convenience_Async()
        {
            Int64Value client = new ArrayClient().GetInt64ValueClient();

            Response response = await client.PutAsync(new long[] { 1234L });
        }
    }
}
