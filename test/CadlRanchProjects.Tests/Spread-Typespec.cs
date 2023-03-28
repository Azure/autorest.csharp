// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Azure;
using System.Net;
using Spread;
using Azure.Core;
using Azure.Identity;
using Spread.Models;

namespace CadlRanchProjects.Tests
{
    public class SpreadCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task Spread_spreadModel() => Test(async (host) =>
        {
            Thing thing = new Thing("dog", 3);
            Response response = await new SpreadClient(host).SpreadModelAsync(thing);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadAlias() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host).SpreadAliasAsync("dog", 3);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadMultiTargetAlias() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host).SpreadMultiTargetAliasAsync("1", 1, "dog", 3);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadAliasWithModel() => Test(async (host) =>
        {
            Thing thing = new Thing("dog", 3);
            Response response = await new SpreadClient(host).SpreadAliasWithModelAsync("1", 1, thing);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadAliasWithSpreadAlias() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host).SpreadAliasWithSpreadAliasAsync("1", 1, "dog", 3);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadAliasWithoutOptionalProps() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host).SpreadAliasWithOptionalPropsAsync("1", 1, "dog", new[] { 1, 2, 3 });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Spread_spreadAliasWithOptionalProps() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host).SpreadAliasWithOptionalPropsAsync("2", 1, "dog", new[] { 1, 2, 3, 4 }, "red", 3, new[] { "a", "b" });
            Assert.AreEqual(204, response.Status);
        });
    }
}
