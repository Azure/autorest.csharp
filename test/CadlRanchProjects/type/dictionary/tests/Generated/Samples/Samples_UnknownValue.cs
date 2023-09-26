// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type._Dictionary;

namespace _Type._Dictionary.Samples
{
    public class Samples_UnknownValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = client.GetUnknownValue(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = await client.GetUnknownValueAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_Convenience()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, BinaryData>> response = client.GetUnknownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_Convenience_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, BinaryData>> response = await client.GetUnknownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_AllParameters()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = client.GetUnknownValue(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_AllParameters_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = await client.GetUnknownValueAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUnknownValue_AllParameters_Convenience()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, BinaryData>> response = client.GetUnknownValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUnknownValue_AllParameters_Convenience_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, BinaryData>> response = await client.GetUnknownValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new object(),
            });
            Response response = client.Put(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = client.Put(new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson(new object())
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson(new object())
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new object(),
            });
            Response response = client.Put(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = client.Put(new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson(new object())
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            UnknownValue client = new DictionaryClient().GetUnknownValueClient("1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson(new object())
            });
        }
    }
}
