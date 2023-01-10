// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using Pagination;

namespace CadlRanchProjects.Tests
{
    public class PaginationCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task Pagination_UsingCustomPageTemplate() => Test(async (host) =>
        {
            var tokenPolicy = new MockBearerTokenAuthenticationPolicy(new MockCredential(), PaginationClient.TokenScopes);

            var pageableAsync = new PaginationClient(host, new MockCredential(), null, tokenPolicy).GetPaginationLedgerEntryValuesAsync();
            bool firstPage = true;
            await foreach (var page in pageableAsync.AsPages())
            {
                var value = page.Values.First();
                if (firstPage)
                {
                    Assert.AreEqual("contents", page.Values.First().Contents);
                    firstPage = false;
                }
                else
                {
                    Assert.AreEqual("contents2", page.Values.First().Contents);
                }
            }
        });

        [Test]
        public Task Pagination_UsingPageTemplate() => Test(async (host) =>
        {
            var tokenPolicy = new MockBearerTokenAuthenticationPolicy(new MockCredential(), PaginationClient.TokenScopes);

            var pageableAsync = new PaginationClient(host, new MockCredential(), null, tokenPolicy).GetLedgerEntryValuesAsync();
            bool firstPage = true;
            await foreach (var page in pageableAsync.AsPages())
            {
                var value = page.Values.First();
                if (firstPage)
                {
                    Assert.AreEqual("contents", page.Values.First().Contents);
                    firstPage = false;
                }
                else
                {
                    Assert.AreEqual("contents2", page.Values.First().Contents);
                }
            }
        });
    }
}
