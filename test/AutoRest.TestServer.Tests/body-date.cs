// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDateTest: TestServerTestBase
    {
        public BodyDateTest(TestServerVersion version) : base(version, "date") { }

        [Test]
        public Task GetDateInvalid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDateMax() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDateMin() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDateNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDateOverflow() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDateUnderflow() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task PutDateMax() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDateMin() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
