// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Model.Usage.Models;

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
        public void Example_Input_AllParameters()
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
        public async Task Example_Input_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = await client.InputAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Input_AllParameters_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = await client.InputAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Input_Convenience_Async()
        {
            var client = new UsageClient();

            var input = new InputRecord("<requiredProp>");
            var result = await client.InputAsync(input);
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
        public void Example_Output_AllParameters()
        {
            var client = new UsageClient();

            Response response = client.Output(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Output_Async()
        {
            var client = new UsageClient();

            Response response = await client.OutputAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Output_AllParameters_Async()
        {
            var client = new UsageClient();

            Response response = await client.OutputAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Output_Convenience_Async()
        {
            var client = new UsageClient();

            var result = await client.OutputAsync();
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

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputAndOutput_AllParameters()
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

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputAndOutput_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = await client.InputAndOutputAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputAndOutput_AllParameters_Async()
        {
            var client = new UsageClient();

            var data = new
            {
                requiredProp = "<requiredProp>",
            };

            Response response = await client.InputAndOutputAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputAndOutput_Convenience_Async()
        {
            var client = new UsageClient();

            var body = new InputOutputRecord("<requiredProp>");
            var result = await client.InputAndOutputAsync(body);
        }
    }
}
