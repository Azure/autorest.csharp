// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace _Type._Enum.Fixed.Samples
{
    public class Samples_FixedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetKnownValue()
        {
            var client = new FixedClient();

            Response response = client.GetKnownValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutKnownValue()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutKnownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUnknownValue()
        {
            var client = new FixedClient();

            var data = "Monday";

            Response response = client.PutUnknownValue(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
