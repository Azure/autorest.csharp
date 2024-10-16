// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Azure.Lro.Rpc;
using _Azure.Lro.Rpc.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests.lro
{
    public class LongRunningOperation : CadlRanchTestBase
    {
        [Test]
        public Task LongRunningRpc_Completed() => Test(async (host) =>
        {
            var option = new GenerationOptions("text");
            var response = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Completed, option);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("text data", response.Value.Data);
        });

        [Test]
        public Task LongRunningRpc_Started() => Test(async (host) =>
        {
            var option = new GenerationOptions("text");
            var response = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Started, option);
            Assert.AreEqual(202, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.GetRawResponse().Headers.TryGetValue("operation-location", out string operationLocation));
            Assert.AreEqual(true, operationLocation.Contains("/azure/core/lro/rpc/generations/operations/operation1"));
        });


    }
}
