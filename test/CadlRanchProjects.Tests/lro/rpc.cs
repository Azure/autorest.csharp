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
using _Azure.Lro.Rpc;
using _Azure.Lro.Rpc.Models;
using System.Net;

namespace CadlRanchProjects.Tests.lro
{
    public class LroRpcTest : CadlRanchTestBase
    {
        [Test]
        public Task Delete() => Test(async (host) =>
        {
            var operation = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Started, new GenerationOptions("text"));

            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(202, operation.GetRawResponse().Status);
            //Assert.AreEqual("operation1", operation.Value.Data);
        });
    }
}
