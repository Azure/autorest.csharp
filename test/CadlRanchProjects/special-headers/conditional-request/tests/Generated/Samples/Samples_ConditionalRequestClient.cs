// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SpecialHeaders.ConditionalRequest;

namespace SpecialHeaders.ConditionalRequest.Samples
{
    public class Samples_ConditionalRequestClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostIfMatch()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = client.PostIfMatch();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostIfMatch_Async()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = await client.PostIfMatchAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostIfMatch_AllParameters()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = client.PostIfMatch(new ETag("<ifMatch>"));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostIfMatch_AllParameters_Async()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = await client.PostIfMatchAsync(new ETag("<ifMatch>"));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostIfNoneMatch()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = client.PostIfNoneMatch();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostIfNoneMatch_Async()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = await client.PostIfNoneMatchAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostIfNoneMatch_AllParameters()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = client.PostIfNoneMatch(new ETag("<ifNoneMatch>"));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostIfNoneMatch_AllParameters_Async()
        {
            ConditionalRequestClient client = new ConditionalRequestClient();

            Response response = await client.PostIfNoneMatchAsync(new ETag("<ifNoneMatch>"));
        }
    }
}
