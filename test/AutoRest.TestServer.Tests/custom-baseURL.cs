// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        [Test]
        public Task CustomBaseUri() => TestStatus(async (host, pipeline) =>
            await GetClient<custom_baseUrl.PathsClient>(pipeline, host.ToString().Replace("http://", string.Empty)).GetEmptyAsync( string.Empty));

        [Test]
        public Task CustomBaseUriMoreOptions() => TestStatus(async (host, pipeline) =>
            await GetClient<custom_baseUrl_more_options.PathsClient>(pipeline, host.ToString(), "test12").GetEmptyAsync( string.Empty, string.Empty, "key1",  "v1"));

        [Test]
        public void ThrowsIfHostIsNull()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => GetClient<custom_baseUrl.PathsClient>(HttpPipelineBuilder.Build(new TestOptions()), null));
            Assert.AreEqual(typeof(ArgumentNullException), ex.InnerException.GetType());
        }
    }
}
