// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using dpg_customization_LowLevel;

namespace dpg_customization_LowLevel.Samples
{
    public class Samples_DPGClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Response response = client.GetModel("<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Response response = await client.GetModelAsync("<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModel_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Response response = client.GetModel("<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModel_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Response response = await client.GetModelAsync("<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostModel()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = client.PostModel("<mode>", content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostModel_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = await client.PostModelAsync("<mode>", content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostModel_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = client.PostModel("<mode>", content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostModel_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = await client.PostModelAsync("<mode>", content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPages()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            foreach (BinaryData item in client.GetPages("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPages_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            await foreach (BinaryData item in client.GetPagesAsync("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPages_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            foreach (BinaryData item in client.GetPages("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPages_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            await foreach (BinaryData item in client.GetPagesAsync("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Lro()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Operation<BinaryData> operation = client.Lro(WaitUntil.Completed, "<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Lro_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Operation<BinaryData> operation = await client.LroAsync(WaitUntil.Completed, "<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Lro_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Operation<BinaryData> operation = client.Lro(WaitUntil.Completed, "<mode>", null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Lro_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = new DPGClient(credential);

            Operation<BinaryData> operation = await client.LroAsync(WaitUntil.Completed, "<mode>", null);
        }
    }
}
