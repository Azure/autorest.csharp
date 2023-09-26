// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Specs_.Azure.ClientGenerator.Core.Usage;
using _Specs_.Azure.ClientGenerator.Core.Usage.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Usage.Samples
{
    public class Samples_UsageClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput()
        {
            UsageClient client = new UsageClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.InputToInputOutput(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_Async()
        {
            UsageClient client = new UsageClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.InputToInputOutputAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput_Convenience()
        {
            UsageClient client = new UsageClient();

            InputModel body = new InputModel("<name>");
            Response response = client.InputToInputOutput(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_Convenience_Async()
        {
            UsageClient client = new UsageClient();

            InputModel body = new InputModel("<name>");
            Response response = await client.InputToInputOutputAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput_AllParameters()
        {
            UsageClient client = new UsageClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.InputToInputOutput(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_AllParameters_Async()
        {
            UsageClient client = new UsageClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.InputToInputOutputAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_InputToInputOutput_AllParameters_Convenience()
        {
            UsageClient client = new UsageClient();

            InputModel body = new InputModel("<name>");
            Response response = client.InputToInputOutput(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_InputToInputOutput_AllParameters_Convenience_Async()
        {
            UsageClient client = new UsageClient();

            InputModel body = new InputModel("<name>");
            Response response = await client.InputToInputOutputAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput()
        {
            UsageClient client = new UsageClient();

            Response response = client.OutputToInputOutput(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_Async()
        {
            UsageClient client = new UsageClient();

            Response response = await client.OutputToInputOutputAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput_Convenience()
        {
            UsageClient client = new UsageClient();

            Response<OutputModel> response = client.OutputToInputOutput();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_Convenience_Async()
        {
            UsageClient client = new UsageClient();

            Response<OutputModel> response = await client.OutputToInputOutputAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput_AllParameters()
        {
            UsageClient client = new UsageClient();

            Response response = client.OutputToInputOutput(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_AllParameters_Async()
        {
            UsageClient client = new UsageClient();

            Response response = await client.OutputToInputOutputAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OutputToInputOutput_AllParameters_Convenience()
        {
            UsageClient client = new UsageClient();

            Response<OutputModel> response = client.OutputToInputOutput();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_OutputToInputOutput_AllParameters_Convenience_Async()
        {
            UsageClient client = new UsageClient();

            Response<OutputModel> response = await client.OutputToInputOutputAsync();
        }
    }
}
