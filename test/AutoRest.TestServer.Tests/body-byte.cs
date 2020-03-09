// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_byte;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyByte : TestServerTestBase
    {
        public BodyByte(TestServerVersion version) : base(version, "byte") { }

        [Test]
        public Task GetByteEmpty() => Test(async (host, pipeline) =>
        {
            CollectionAssert.IsEmpty((await new ByteClient(ClientDiagnostics, pipeline, host).GetEmptyAsync()).Value);
        });

        [Test]
        public Task GetByteInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await new ByteClient(ClientDiagnostics, pipeline, host).GetInvalidAsync());
        });

        [Test]
        public Task GetByteNonAscii() => Test(async (host, pipeline) => {
            CollectionAssert.AreEqual(new byte[]{ 255, 254, 253, 252, 251, 250, 249, 248, 247, 246 },
                (await new ByteClient(ClientDiagnostics, pipeline, host).GetNonAsciiAsync()).Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetByteNull() => Test(async (host, pipeline) =>
        {
            Assert.Null(await new ByteClient(ClientDiagnostics, pipeline, host).GetNullAsync());
        });

        [Test]
        public Task PutByteNonAscii() => TestStatus(async (host, pipeline) => await new ByteClient(ClientDiagnostics, pipeline, host).PutNonAsciiAsync( new byte[] { 255, 254, 253, 252, 251, 250, 249, 248, 247, 246 }));

    }
}
