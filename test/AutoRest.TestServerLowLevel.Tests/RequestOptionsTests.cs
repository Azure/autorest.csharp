// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class RequestOptionsTests : TestServerLowLevelTestBase
    {
        [Test]
        public Task RequestThrowsByDefault () => Test(host =>
        {
            PathsClient paths = new PathsClient(Key, host);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await paths.EnumValidAsync("no color"));
        }, ignoreScenario: true);

        [Test]
        public Task RequestThrowsCanBeDisabled () => Test(host =>
        {
            PathsClient paths = new PathsClient(Key, host);
            Assert.DoesNotThrowAsync(async () => await paths.EnumValidAsync("no color", new Azure.RequestOptions(Azure.ResponseStatusOption.NoThrow)));
        }, ignoreScenario: true);

        [Test]
        public Task RequestCallback () => Test(async host =>
        {
            bool callbackInvoked = false;
            PathsClient paths = new PathsClient(Key, host);
            await paths.EnumValidAsync("green color", new Azure.RequestOptions(_ => callbackInvoked = true));
            Assert.True(callbackInvoked);
        }, ignoreScenario: true);
    }
}
