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

namespace ParametersCadl.Samples
{
    public class Samples_ParametersCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation2()
        {
            var client = new ParametersCadlClient();

            Response response = client.Operation2(1234, 1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }
    }
}
