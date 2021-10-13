// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_file_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyFileTests : TestServerLowLevelTestBase
    {
        private string SamplePngPath = Path.Combine(TestServerV1.GetBaseDirectory(), "routes", "sample.png");

        [Test]
        public Task FileStreamEmpty() => Test(async (host) =>
        {
            var result = await new FilesClient(Key, host).GetEmptyFileAsync(new());
            Assert.AreEqual(0, await result.ContentStream.ReadAsync(new byte[10]));
        });

        [Test]
        public Task FileStreamNonempty() => Test(async (host) =>
        {
            var result = await new FilesClient(Key, host).GetFileAsync(new());
            var memoryStream = new MemoryStream();
            await result.ContentStream.CopyToAsync(memoryStream);

            CollectionAssert.AreEqual(File.ReadAllBytes(SamplePngPath), memoryStream.ToArray());
        });
    }
}
