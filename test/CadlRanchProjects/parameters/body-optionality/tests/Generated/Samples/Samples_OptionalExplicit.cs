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
using Parameters.BodyOptionality;
using Parameters.BodyOptionality.Models;

namespace Parameters.BodyOptionality.Samples
{
    public class Samples_OptionalExplicit
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Set()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = null;
            Response response = client.Set(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Set_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = null;
            Response response = await client.SetAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Set_Convenience()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            Response response = client.Set();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Set_Convenience_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            Response response = await client.SetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Set_AllParameters()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Set(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Set_AllParameters_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.SetAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Set_AllParameters_Convenience()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            BodyModel body = new BodyModel("<name>");
            Response response = client.Set(body: body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Set_AllParameters_Convenience_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            BodyModel body = new BodyModel("<name>");
            Response response = await client.SetAsync(body: body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Omit()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = null;
            Response response = client.Omit(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Omit_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = null;
            Response response = await client.OmitAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Omit_Convenience()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            Response response = client.Omit();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Omit_Convenience_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            Response response = await client.OmitAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Omit_AllParameters()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Omit(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Omit_AllParameters_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.OmitAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Omit_AllParameters_Convenience()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            BodyModel body = new BodyModel("<name>");
            Response response = client.Omit(body: body);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Omit_AllParameters_Convenience_Async()
        {
            OptionalExplicit client = new BodyOptionalityClient().GetOptionalExplicitClient();

            BodyModel body = new BodyModel("<name>");
            Response response = await client.OmitAsync(body: body);
            Console.WriteLine(response.Status);
        }
    }
}
