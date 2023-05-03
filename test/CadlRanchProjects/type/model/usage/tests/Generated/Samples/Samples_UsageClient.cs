// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace _Type.Model.Usage.Samples
{
    public class Samples_UsageClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Input()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = client.Input(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Output()
        {
            var client = new UsageClient();

            Response response = client.Output(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputAndOutput()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = client.InputAndOutput(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }
    }
}
