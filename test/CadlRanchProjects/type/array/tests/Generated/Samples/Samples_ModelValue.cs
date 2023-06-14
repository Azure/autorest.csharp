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
using _Type._Array.Models;

namespace _Type._Array.Samples
{
    internal class Samples_ModelValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_AllParameters()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("property").ToString());
            Console.WriteLine(result[0].GetProperty("children")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_AllParameters_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("property").ToString());
            Console.WriteLine(result[0].GetProperty("children")[0].GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Convenience_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var result = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var data = new[] {
    new {
        property = "<property>",
    }
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var data = new[] {
    new {
        property = "<property>",
    }
};

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var data = new[] {
    new {
        property = "<property>",
    }
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var data = new[] {
    new {
        property = "<property>",
    }
};

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new ArrayClient().GetModelValueClient("1.0.0");

            var body = new object();
            var result = await client.PutAsync(body);
        }
    }
}
