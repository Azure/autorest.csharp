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
        public void Example_Get400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get400();
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
        public void Example_Head401()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head401();
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
        public void Example_Options403()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options403();
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
        public void Example_Head410()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head410();
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
        public void Example_Options412()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Options412();
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
        public void Example_Get416()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Get416();
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
        public void Example_Head429()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpClientFailureClient(credential);

            Response response = client.Head429();
            Console.WriteLine(response.Status);
        }
    }
}
