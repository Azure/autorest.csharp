// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ModelFlatteningTests : TestServerTestBase
    {
        public ModelFlatteningTests(TestServerVersion version) : base(version, "model-flatten") { }

        [Test]
        public Task GetModelFlattenArray() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetModelFlattenDictionary() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetModelFlattenResourceCollection() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task PostModelFlattenCustomParameter() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutModelFlattenArray() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutModelFlattenCustomBase() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutModelFlattenCustomGroupedParameter() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutModelFlattenDictionary() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutModelFlattenResourceCollection() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
