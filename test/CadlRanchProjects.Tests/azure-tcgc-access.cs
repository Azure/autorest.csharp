using _Specs_.Azure.ClientGenerator.Core.Access;
using _Specs_.Azure.ClientGenerator.Core.Access.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CadlRanchProjects.Tests
{
    public class AzureTcgcAccessTests: CadlRanchTestBase
    {
        [Test]
        public Task Azure_ClientGenerator_Core_Access_Public() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetPublicClient().NoDecoratorInPublicAsync("name");
            Assert.AreEqual("name", response1.Value.Name);

            var response2 = await new AccessClient(host, null).GetPublicClient().PublicDecoratorInPublicAsync("name");
            Assert.AreEqual("name", response2.Value.Name);

            Assert.IsNotNull(typeof(Public).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Public).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Public).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Public).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsTrue(typeof(NoDecoratorModelInPublic).IsVisible);
            Assert.IsTrue(typeof(PublicDecoratorModelInPublic).IsVisible);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Access_Internal() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetInternalClient().NoDecoratorInInternalAsync("name");
            Assert.AreEqual("name", response1.Value.Name);

            var response2 = await new AccessClient(host, null).GetInternalClient().InternalDecoratorInInternalAsync("name");
            Assert.AreEqual("name", response2.Value.Name);

            var response3 = await new AccessClient(host, null).GetInternalClient().PublicDecoratorInInternalAsync("name");
            Assert.AreEqual("name", response3.Value.Name);

            Assert.IsNotNull(typeof(Internal).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Internal).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Internal).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Internal).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Internal).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Internal).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsFalse(typeof(NoDecoratorModelInInternal).IsVisible);
            Assert.IsFalse(typeof(InternalDecoratorModelInInternal).IsVisible);
            Assert.IsTrue(typeof(PublicDecoratorModelInInternal).IsVisible);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Access_Shared() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetSharedClient().PublicAsync("name");
            Assert.AreEqual("name", response1.Value.Name);

            var response2 = await new AccessClient(host, null).GetSharedClient().InternalAsync("name");
            Assert.AreEqual("name", response2.Value.Name);

            Assert.IsNotNull(typeof(Shared).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Shared).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Shared).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }).IsPublic);
            Assert.IsNotNull(typeof(Shared).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }).IsPublic);

            Assert.IsTrue(typeof(SharedModel).IsVisible);
        });

        [Test]
        public Task Azure_ClientGenerator_Core_Access_Relative() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetRelativeClient().OperationAsync("name");
            Assert.AreEqual("Madge", response1.Value.Name);
            Assert.AreEqual("Madge", response1.Value.Inner.Name);

            var response2 = await new AccessClient(host, null).GetRelativeClient().DiscriminatorAsync("name");
            Assert.AreEqual("Madge", response2.Value.Name);

            Assert.IsNotNull(typeof(Relative).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Relative).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(Relative).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(Relative).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsFalse(typeof(OuterModel).IsVisible);
            Assert.IsFalse(typeof(BaseModel).IsVisible);
            Assert.IsFalse(typeof(InnerModel).IsVisible);
            Assert.IsFalse(typeof(AbstractModel).IsVisible);
            Assert.IsFalse(typeof(RealModel).IsVisible);
        });
    }
}
