using System.Threading.Tasks;
using System;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using _Specs_.Azure.ClientGenerator.Core.Internal;
using System.Threading;
using _Specs_.Azure.ClientGenerator.Core.Internal.Models;
using System.Reflection;

namespace CadlRanchProjects.Tests
{
    public class AzureTcgcInternalTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_ClientGenerator_Core_Internal_publicOnly() => Test(async (host) =>
        {
            var response = await new InternalClient(host, null).PublicOnlyAsync("name");
            Assert.AreEqual("name", response.Value.Name);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Internal_internalOnly() => Test(async (host) =>
        {
            var response = await new InternalClient(host, null).InternalOnlyAsync("name");
            Assert.AreEqual("name", response.Value.Name);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Internal_Shared() => Test(async (host) =>
        {
            var response = await new InternalClient(host, null).GetSharedClient().PublicAsync("name");
            Assert.AreEqual("name", response.Value.Name);

            response = await new InternalClient(host, null).GetSharedClient().InternalAsync("name");
            Assert.AreEqual("name", response.Value.Name);
        });

        [Test]
        public void ModifierTests()
        {
            Assert.IsNotNull(typeof(InternalClient).GetMethod("PublicOnlyAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(InternalClient).GetMethod("PublicOnlyAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(InternalClient).GetMethod("InternalOnlyAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(InternalClient).GetMethod("InternalOnlyAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Shared).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Shared).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Shared).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }).IsPublic);
            Assert.IsNotNull(typeof(Shared).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }).IsPublic);

            Assert.IsTrue(typeof(PublicModel).IsVisible);
            Assert.IsFalse(typeof(InternalModel).IsVisible);
            Assert.IsTrue(typeof(SharedModel).IsVisible);
        }
    }
}
