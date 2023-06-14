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

namespace httpInfrastructure_LowLevel.Samples
{
    public class Samples_HttpClientFailureClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options400();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options400Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete400(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete400Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head401()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head401();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head401_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head401();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head401_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head401Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head401_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head401Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get402()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get402();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get402_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get402();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get402_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get402Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get402_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get402Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options403()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options403();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options403_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options403();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options403_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options403Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options403_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options403Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get403()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get403();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get403_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get403();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get403_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get403Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get403_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get403Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put404()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put404(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put404_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put404(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put404_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put404Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put404_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put404Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch405()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch405(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch405_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch405(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch405_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch405Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch405_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch405Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post406()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post406(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post406_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post406(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post406_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post406Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post406_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post406Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete407()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete407(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete407_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete407(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete407_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete407Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete407_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete407Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put409()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put409(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put409_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put409(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put409_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put409Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put409_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put409Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head410()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head410();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head410_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head410();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head410_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head410Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head410_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head410Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get411()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get411();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get411_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get411();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get411_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get411Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get411_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get411Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options412()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options412();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options412_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options412();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options412_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options412Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options412_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Options412Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get412()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get412();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get412_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get412();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get412_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get412Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get412_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get412Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put413()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put413(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put413_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Put413(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put413_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put413Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put413_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Put413Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch414()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch414(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch414_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Patch414(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch414_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch414Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch414_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Patch414Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post415()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post415(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post415_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Post415(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post415_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post415Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post415_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Post415Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get416()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get416();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get416_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get416();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get416_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get416Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get416_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Get416Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete417()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete417(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete417_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = client.Delete417(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete417_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete417Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete417_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            var data = true;

            Response response = await client.Delete417Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head429()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head429();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head429_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head429();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head429_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head429Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head429_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = await client.Head429Async();
            Console.WriteLine(response.Status);
        }
    }
}
