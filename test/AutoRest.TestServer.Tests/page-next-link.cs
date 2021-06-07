// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using PageNextLink;

namespace AutoRest.TestServer.Tests
{
    public class PageNextLinkTests : TestServerTestBase
    {
        [Test]
        public void RestClientDroppedMethods()
        {
            var client = typeof(PageNextLink.PagingRestClient);
            Assert.IsNull(client.GetMethod ("CreateNextFragmentNextPageRequest", BindingFlags.Instance | BindingFlags.NonPublic), "CreateNextFragmentNextPageRequest should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPageAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPageAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragmentNextPage", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentNextPage should not be generated");
        }

        [Test]
        public void ClientDroppedMethods()
        {
            var client = typeof(PageNextLink.PagingClient);
            Assert.IsNull(client.GetMethod ("NextFragmentAsync", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragmentAsync should not be generated");
            Assert.IsNull(client.GetMethod ("NextFragment", BindingFlags.Instance | BindingFlags.NonPublic), "NextFragment should not be generated");
        }
    }
}
