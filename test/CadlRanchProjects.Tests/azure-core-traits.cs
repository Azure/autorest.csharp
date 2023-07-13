using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Traits;
using _Specs_.Azure.Core.Traits.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureCoreTraitsTests: CadlRanchTestBase
    {
        [Test]
        public Task Azure_Core_Traits_smokeTest() => Test(async (host) =>
        {
            User response = await new TraitsClient(host, null).SmokeTestAsync(1, "123", new RequestConditions() { IfMatch = new ETag("valid"), IfNoneMatch = new ETag("invalid"), IfUnmodifiedSince = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT"), IfModifiedSince = DateTimeOffset.Parse("Thu, 26 Aug 2021 14:38:00 GMT") });
            Assert.AreEqual("Madge", response.Name);
        });

        [Test]
        public Task RepeatableAction() => Test(async (host) =>
        {
            UserActionResponse response = await new TraitsClient(host, null).RepeatableActionAsync(1, new UserActionParam("test"));
            Assert.AreEqual("test", response.UserActionResult);
        });

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            foreach (var m in typeof(TraitsClient).GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name.StartsWith("RepeatableAction")))
            {
                Assert.False(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"));
            }
        }
    }
}
