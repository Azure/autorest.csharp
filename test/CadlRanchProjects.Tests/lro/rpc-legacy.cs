// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using _Azure.Lro.RpcLegacy;
using _Azure.Lro.RpcLegacy.Models;
using System.Net;

namespace CadlRanchProjects.Tests
{
    public class LroRpcLegacyTests : CadlRanchTestBase
    {
        [Test]
        public Task CreateOrReplace() => Test(async (host) =>
        {
            var operation = await new LegacyClient(host, null).CreateJobAsync(WaitUntil.Completed, new JobData("async job"));
            var result = operation.Value;

            Assert.AreEqual("job1", result.JobId);
            Assert.AreEqual("async job", result.Comment);
            Assert.AreEqual(JobStatus.Succeeded, result.Status);
            Assert.AreEqual(new List<string>{"job1 result"}, result.Results);
        });
    }
}
