// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using SpecialHeaders.Repeatability;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace CadlRanchProjects.Tests
{
    public class RepeatabilityHeaderTests : CadlRanchTestBase
    {
        [Test]
        public Task ImmediateSuccess() => Test(async (host) =>
        {
            Response response = await new RepeatabilityClient(host, null).ImmediateSuccessAsync();
            Assert.AreEqual(204, response.Status);
            Assert.IsTrue(response.Headers.TryGetValue("repeatability-result", out var headerValue));
            Assert.AreEqual("accepted", headerValue);
        });

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            foreach (var m in typeof(RepeatabilityClient).GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name.StartsWith("ImmediateSuccess")))
            {
                Assert.False(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"));
            }
        }
    }
}
